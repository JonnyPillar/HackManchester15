namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedextrafuekds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Bio", c => c.String());
            AddColumn("dbo.User", "ProfileImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "ProfileImageUrl");
            DropColumn("dbo.User", "Bio");
        }
    }
}
