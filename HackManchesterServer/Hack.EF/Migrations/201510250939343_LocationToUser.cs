namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Location");
        }
    }
}
