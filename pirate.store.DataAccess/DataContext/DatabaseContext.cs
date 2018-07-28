using pirate.store.Domain.Entities;
using pirate.store.Domain.Models;
using System.Data.Entity;

namespace pirate.store.DataAccess.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<AdminViewModel> AdminViewModels { get; set; }


        public DatabaseContext() : base("name=PSdb_local-connection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            //modelBuilder.Entity<Item>()
            //    .HasRequired<Category>(s => s.Category)
            //    .WithMany(g => g.ItemsOnCategory)
            //    .HasForeignKey<int>(s => s.CategoryId);

            //modelBuilder.Entity<Item>()
            //    .HasRequired<Subcategory>(s => s.Subcategory)
            //    .WithMany(g => g.ItemsOnSubcategory)
            //    .HasForeignKey<int>(s => s.SubcategoryId);

            modelBuilder.Entity<Subcategory>()
                .HasRequired<Category>(s => s.Category)
                .WithMany(g => g.SubCategoriesOnCategory)
                .HasForeignKey<int>(s => s.CategoryId);

            modelBuilder.Entity<Item>()
                .HasRequired<Catalog>(s => s.Catalog)
                .WithMany(g => g.ItemsOnCatalog)
                .HasForeignKey<int>(s => s.CatalogId);



        }
    }
}