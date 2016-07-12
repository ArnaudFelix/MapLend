namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "User_Id", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "User_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "User_Id");
            AddForeignKey("dbo.AspNetUsers", "User_Id", "dbo.Users", "Id");
        }
    }
}
