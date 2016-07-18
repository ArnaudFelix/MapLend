namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeviewmodels : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ToolViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ToolViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
