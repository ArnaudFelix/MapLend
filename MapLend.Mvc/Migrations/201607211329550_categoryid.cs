namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tools", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Tools", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Tools", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Tools", "Category_Id", c => c.Int());
            CreateIndex("dbo.Tools", "Category_Id");
            AddForeignKey("dbo.Tools", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tools", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Tools", new[] { "Category_Id" });
            AlterColumn("dbo.Tools", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tools", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Tools", "CategoryId");
            AddForeignKey("dbo.Tools", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
