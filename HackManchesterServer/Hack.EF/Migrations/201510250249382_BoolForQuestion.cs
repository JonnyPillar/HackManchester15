namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolForQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "PeopleEnteredInQuestion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "PeopleEnteredInQuestion");
        }
    }
}
