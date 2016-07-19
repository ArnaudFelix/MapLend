namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lendrating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lends", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lends", "Rating");
        }
    }
}
