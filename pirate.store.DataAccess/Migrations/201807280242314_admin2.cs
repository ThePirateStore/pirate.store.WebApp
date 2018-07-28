namespace pirate.store.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminViewModels", "Item_Id", c => c.Int());
            CreateIndex("dbo.AdminViewModels", "Item_Id");
            AddForeignKey("dbo.AdminViewModels", "Item_Id", "dbo.Items", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminViewModels", "Item_Id", "dbo.Items");
            DropIndex("dbo.AdminViewModels", new[] { "Item_Id" });
            DropColumn("dbo.AdminViewModels", "Item_Id");
        }
    }
}
