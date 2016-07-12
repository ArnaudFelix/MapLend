namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prenom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Fistname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Fistname");
        }
    }
}
