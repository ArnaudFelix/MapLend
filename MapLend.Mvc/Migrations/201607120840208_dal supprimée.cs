namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dalsupprimée : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Firstname", c => c.String());
            DropColumn("dbo.Users", "Fistname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Fistname", c => c.String());
            DropColumn("dbo.Users", "Firstname");
        }
    }
}
