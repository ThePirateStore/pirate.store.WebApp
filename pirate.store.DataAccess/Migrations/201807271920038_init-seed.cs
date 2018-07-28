namespace pirate.store.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initseed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Company = c.String(),
                        Year = c.Int(),
                        Rate = c.Int(),
                        Quality = c.Int(),
                        Version = c.String(),
                        UniqueCode = c.String(),
                        MegaLink = c.String(),
                        CoffeeLink = c.String(),
                        ImageLink = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        FileFormat = c.String(),
                        FileSize = c.Int(),
                        CatalogId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Category_Id = c.Int(),
                        Subcategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catalogs", t => t.CatalogId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_Id)
                .Index(t => t.CatalogId)
                .Index(t => t.Category_Id)
                .Index(t => t.Subcategory_Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Catalog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Catalogs", t => t.Catalog_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Catalog_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "Catalog_Id", "dbo.Catalogs");
            DropForeignKey("dbo.Catalogs", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Items", "Subcategory_Id", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Items", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Items", "CatalogId", "dbo.Catalogs");
            DropIndex("dbo.Subcategories", new[] { "Catalog_Id" });
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "Subcategory_Id" });
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropIndex("dbo.Items", new[] { "CatalogId" });
            DropIndex("dbo.Catalogs", new[] { "CategoryId" });
            DropTable("dbo.Subcategories");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
            DropTable("dbo.Catalogs");
        }
    }
}
