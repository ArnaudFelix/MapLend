namespace Map.Business.Migrations
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
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
                "dbo.Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserMaps",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Map_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Map_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Maps", t => t.Map_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Map_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tools", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Tools", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.UserMaps", "Map_Id", "dbo.Maps");
            DropForeignKey("dbo.UserMaps", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Maps", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.UserMaps", new[] { "Map_Id" });
            DropIndex("dbo.UserMaps", new[] { "User_Id" });
            DropIndex("dbo.Tools", new[] { "User_Id" });
            DropIndex("dbo.Tools", new[] { "Category_Id" });
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropIndex("dbo.Maps", new[] { "Address_Id" });
            DropTable("dbo.UserMaps");
            DropTable("dbo.Tools");
            DropTable("dbo.Users");
            DropTable("dbo.Maps");
            DropTable("dbo.Categories");
            DropTable("dbo.Addresses");
        }
    }
}
