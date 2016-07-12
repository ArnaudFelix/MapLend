namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Photo_Id", c => c.Int());
            CreateIndex("dbo.Users", "Photo_Id");
            AddForeignKey("dbo.Users", "Photo_Id", "dbo.UserPhotoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Photo_Id", "dbo.UserPhotoes");
            DropIndex("dbo.Users", new[] { "Photo_Id" });
            DropColumn("dbo.Users", "Photo_Id");
            DropTable("dbo.UserPhotoes");
        }
    }
}
