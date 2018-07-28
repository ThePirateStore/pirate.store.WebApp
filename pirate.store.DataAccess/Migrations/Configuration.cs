namespace pirate.store.DataAccess.Migrations
{
    using pirate.store.DataAccess.DataContext;
    using pirate.store.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseContext ctx)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<Subcategory> subcatList_1 = new List<Subcategory>();
            IList<Subcategory> subcatList_2 = new List<Subcategory>();
            IList<Subcategory> subcatList_3 = new List<Subcategory>();
            IList<Subcategory> subcatList_4 = new List<Subcategory>();
            IList<Subcategory> subcatList_5 = new List<Subcategory>();
            IList<Subcategory> subcatList_6 = new List<Subcategory>();

            subcatList_1.Add(new Subcategory() { Name = "Subcategory h1" });
            subcatList_1.Add(new Subcategory() { Name = "Subcategory h2" });
            subcatList_1.Add(new Subcategory() { Name = "Subcategory h3" });
            subcatList_1.Add(new Subcategory() { Name = "Subcategory h4" });
            subcatList_1.Add(new Subcategory() { Name = "Subcategory h5" });
            subcatList_1.Add(new Subcategory() { Name = "Subcategory h6" });
            subcatList_2.Add(new Subcategory() { Name = "Subcategory a1" });
            subcatList_2.Add(new Subcategory() { Name = "Subcategory a2" });
            subcatList_2.Add(new Subcategory() { Name = "Subcategory a3" });
            subcatList_2.Add(new Subcategory() { Name = "Subcategory a4" });
            subcatList_2.Add(new Subcategory() { Name = "Subcategory a5" });
            subcatList_2.Add(new Subcategory() { Name = "Subcategory a6" });
            subcatList_3.Add(new Subcategory() { Name = "Subcategory b1" });
            subcatList_3.Add(new Subcategory() { Name = "Subcategory b2" });
            subcatList_3.Add(new Subcategory() { Name = "Subcategory b3" });
            subcatList_3.Add(new Subcategory() { Name = "Subcategory b4" });
            subcatList_3.Add(new Subcategory() { Name = "Subcategory b5" });
            subcatList_4.Add(new Subcategory() { Name = "Subcategory c6" });
            subcatList_4.Add(new Subcategory() { Name = "Subcategory c1" });
            subcatList_4.Add(new Subcategory() { Name = "Subcategory c2" });
            subcatList_5.Add(new Subcategory() { Name = "Subcategory d3" });
            subcatList_5.Add(new Subcategory() { Name = "Subcategory d4" });
            subcatList_5.Add(new Subcategory() { Name = "Subcategory d5" });
            subcatList_5.Add(new Subcategory() { Name = "Subcategory d6" });
            subcatList_6.Add(new Subcategory() { Name = "Subcategory r3" });
            subcatList_6.Add(new Subcategory() { Name = "Subcategory r4" });
            subcatList_6.Add(new Subcategory() { Name = "Subcategory r5" });
            subcatList_6.Add(new Subcategory() { Name = "Subcategory r6" });
            ctx.Categories.AddOrUpdate(
                x => x.Name,
                new Category
                {
                    Name = "Books",
                    SubCategoriesOnCategory = new List<Subcategory>(subcatList_1)
                },
                new Category
                {
                    Name = "TV",
                    SubCategoriesOnCategory = new List<Subcategory>(subcatList_2)
                },
                new Category
                {
                    Name = "Movies",
                    SubCategoriesOnCategory = new List<Subcategory>(subcatList_3)
                },
                new Category
                {
                    Name = "Music",
                    SubCategoriesOnCategory = new List<Subcategory>(subcatList_4)
                },
                new Category
                {
                    Name = "Cursos",
                    SubCategoriesOnCategory = new List<Subcategory>(subcatList_5)
                },
                new Category
                {
                    Name = "Software",
                    SubCategoriesOnCategory = new List<Subcategory>(subcatList_6)
                }
                );
            base.Seed(ctx);
            ctx.SaveChanges();

        }
    }
}
