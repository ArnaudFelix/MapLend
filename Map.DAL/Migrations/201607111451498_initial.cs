namespace MapLend.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZipCode = c.String(),
                        City = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Email = c.String(),
                        Pseudo = c.String(),
                        Password = c.String(),
                        Rating = c.Int(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                        ToolStatus_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.ToolStatus", t => t.ToolStatus_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.ToolStatus_Id)
                .Index(t => t.User_Id);
            
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
            
            CreateTable(
                "dbo.MapUsers",
                c => new
                    {
                        Map_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Map_Id, t.User_Id })
                .ForeignKey("dbo.Maps", t => t.Map_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Map_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lends", "Tool_Id", "dbo.Tools");
            DropForeignKey("dbo.Lends", "LendStatus_Id", "dbo.LendStatus");
            DropForeignKey("dbo.Lends", "Lender_Id", "dbo.Users");
            DropForeignKey("dbo.Lends", "Borrower_Id", "dbo.Users");
            DropForeignKey("dbo.Tools", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Tools", "ToolStatus_Id", "dbo.ToolStatus");
            DropForeignKey("dbo.Tools", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.MapUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.MapUsers", "Map_Id", "dbo.Maps");
            DropForeignKey("dbo.Maps", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Lends", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Lends", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.MapUsers", new[] { "User_Id" });
            DropIndex("dbo.MapUsers", new[] { "Map_Id" });
            DropIndex("dbo.Tools", new[] { "User_Id" });
            DropIndex("dbo.Tools", new[] { "ToolStatus_Id" });
            DropIndex("dbo.Tools", new[] { "Category_Id" });
            DropIndex("dbo.Maps", new[] { "Address_Id" });
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropIndex("dbo.Lends", new[] { "Tool_Id" });
            DropIndex("dbo.Lends", new[] { "LendStatus_Id" });
            DropIndex("dbo.Lends", new[] { "Lender_Id" });
            DropIndex("dbo.Lends", new[] { "Borrower_Id" });
            DropIndex("dbo.Lends", new[] { "User_Id1" });
            DropIndex("dbo.Lends", new[] { "User_Id" });
            DropTable("dbo.MapUsers");
            DropTable("dbo.LendStatus");
            DropTable("dbo.ToolStatus");
            DropTable("dbo.Tools");
            DropTable("dbo.Maps");
            DropTable("dbo.Users");
            DropTable("dbo.Lends");
            DropTable("dbo.Categories");
            DropTable("dbo.Addresses");
        }
    }
}
