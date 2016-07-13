namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctionmodèle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tools", "ToolStatus_Id", "dbo.ToolStatus");
            DropForeignKey("dbo.Lends", "LendStatus_Id", "dbo.LendStatus");
            DropIndex("dbo.Lends", new[] { "LendStatus_Id" });
            DropIndex("dbo.Tools", new[] { "ToolStatus_Id" });
            AddColumn("dbo.Lends", "LendStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Tools", "ToolStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Lends", "BeginDate", c => c.DateTime());
            AlterColumn("dbo.Lends", "EndDate", c => c.DateTime());
            DropColumn("dbo.Lends", "LendStatus_Id");
            DropColumn("dbo.Tools", "ToolStatus_Id");
            DropTable("dbo.ToolStatus");
            DropTable("dbo.LendStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LendStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ToolStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tools", "ToolStatus_Id", c => c.Int());
            AddColumn("dbo.Lends", "LendStatus_Id", c => c.Int());
            AlterColumn("dbo.Lends", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lends", "BeginDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tools", "ToolStatus");
            DropColumn("dbo.Lends", "LendStatus");
            CreateIndex("dbo.Tools", "ToolStatus_Id");
            CreateIndex("dbo.Lends", "LendStatus_Id");
            AddForeignKey("dbo.Lends", "LendStatus_Id", "dbo.LendStatus", "Id");
            AddForeignKey("dbo.Tools", "ToolStatus_Id", "dbo.ToolStatus", "Id");
        }
    }
}
