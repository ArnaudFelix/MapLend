namespace MapLend.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Pseudo");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Pseudo", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
        }
    }
}
