namespace pirate.store.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subcategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_Id)
                .Index(t => t.Subcategory_Id);
            
            AddColumn("dbo.Categories", "AdminViewModel_Id", c => c.Int());
            AddColumn("dbo.Items", "AdminViewModel_Id", c => c.Int());
            CreateIndex("dbo.Categories", "AdminViewModel_Id");
            CreateIndex("dbo.Items", "AdminViewModel_Id");
            AddForeignKey("dbo.Categories", "AdminViewModel_Id", "dbo.AdminViewModels", "Id");
            AddForeignKey("dbo.Items", "AdminViewModel_Id", "dbo.AdminViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminViewModels", "Subcategory_Id", "dbo.Subcategories");
            DropForeignKey("dbo.Items", "AdminViewModel_Id", "dbo.AdminViewModels");
            DropForeignKey("dbo.Categories", "AdminViewModel_Id", "dbo.AdminViewModels");
            DropIndex("dbo.Items", new[] { "AdminViewModel_Id" });
            DropIndex("dbo.Categories", new[] { "AdminViewModel_Id" });
            DropIndex("dbo.AdminViewModels", new[] { "Subcategory_Id" });
            DropColumn("dbo.Items", "AdminViewModel_Id");
            DropColumn("dbo.Categories", "AdminViewModel_Id");
            DropTable("dbo.AdminViewModels");
        }
    }
}
