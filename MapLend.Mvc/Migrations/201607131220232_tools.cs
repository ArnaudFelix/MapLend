namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tools : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tools", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Tools", "ToolStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tools", "ToolStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Tools", "Status");
        }
    }
}
