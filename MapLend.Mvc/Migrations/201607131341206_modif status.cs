namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifstatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tools", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Tools", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Tools", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Tools", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tools", "CategoryId");
            AddForeignKey("dbo.Tools", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tools", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Tools", new[] { "CategoryId" });
            AlterColumn("dbo.Tools", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Tools", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Tools", "Category_Id");
            AddForeignKey("dbo.Tools", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
