namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasdgew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "Location", c => c.String());
            AddColumn("dbo.Question", "InYourArea", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "InYourArea");
            DropColumn("dbo.Question", "Location");
        }
    }
}
