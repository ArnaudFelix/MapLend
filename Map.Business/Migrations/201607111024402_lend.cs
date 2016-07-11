namespace Map.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lend : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserMaps", newName: "MapUsers");
            DropPrimaryKey("dbo.MapUsers");
            CreateTable(
                "dbo.Lends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                        User_Id1 = c.Int(),
                        Borrower_Id = c.Int(),
                        Lender_Id = c.Int(),
                        LendStatus_Id = c.Int(),
                        Tool_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .ForeignKey("dbo.Users", t => t.Borrower_Id)
                .ForeignKey("dbo.Users", t => t.Lender_Id)
                .ForeignKey("dbo.LendStatus", t => t.LendStatus_Id)
                .ForeignKey("dbo.Tools", t => t.Tool_Id)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1)
                .Index(t => t.Borrower_Id)
                .Index(t => t.Lender_Id)
                .Index(t => t.LendStatus_Id)
                .Index(t => t.Tool_Id);
            
            CreateTable(
                "dbo.ToolStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LendStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tools", "ToolStatus_Id", c => c.Int());
            AddPrimaryKey("dbo.MapUsers", new[] { "Map_Id", "User_Id" });
            CreateIndex("dbo.Tools", "ToolStatus_Id");
            AddForeignKey("dbo.Tools", "ToolStatus_Id", "dbo.ToolStatus", "Id");
            DropColumn("dbo.Users", "Firstname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Firstname", c => c.String());
            DropForeignKey("dbo.Lends", "Tool_Id", "dbo.Tools");
            DropForeignKey("dbo.Lends", "LendStatus_Id", "dbo.LendStatus");
            DropForeignKey("dbo.Lends", "Lender_Id", "dbo.Users");
            DropForeignKey("dbo.Lends", "Borrower_Id", "dbo.Users");
            DropForeignKey("dbo.Tools", "ToolStatus_Id", "dbo.ToolStatus");
            DropForeignKey("dbo.Lends", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Lends", "User_Id", "dbo.Users");
            DropIndex("dbo.Tools", new[] { "ToolStatus_Id" });
            DropIndex("dbo.Lends", new[] { "Tool_Id" });
            DropIndex("dbo.Lends", new[] { "LendStatus_Id" });
            DropIndex("dbo.Lends", new[] { "Lender_Id" });
            DropIndex("dbo.Lends", new[] { "Borrower_Id" });
            DropIndex("dbo.Lends", new[] { "User_Id1" });
            DropIndex("dbo.Lends", new[] { "User_Id" });
            DropPrimaryKey("dbo.MapUsers");
            DropColumn("dbo.Tools", "ToolStatus_Id");
            DropTable("dbo.LendStatus");
            DropTable("dbo.ToolStatus");
            DropTable("dbo.Lends");
            AddPrimaryKey("dbo.MapUsers", new[] { "User_Id", "Map_Id" });
            RenameTable(name: "dbo.MapUsers", newName: "UserMaps");
        }
    }
}
