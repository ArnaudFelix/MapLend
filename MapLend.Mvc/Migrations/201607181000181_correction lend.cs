namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctionlend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lends", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Lends", "LendStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lends", "LendStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Lends", "Status");
        }
    }
}
