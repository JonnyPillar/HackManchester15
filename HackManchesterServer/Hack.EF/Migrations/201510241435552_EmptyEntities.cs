namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endorsements",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionTags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Forename", c => c.String());
            AddColumn("dbo.Users", "Surname", c => c.String());
            AddColumn("dbo.Users", "Token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Token");
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "Forename");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Username");
            DropTable("dbo.QuestionTags");
            DropTable("dbo.Questions");
            DropTable("dbo.Offers");
            DropTable("dbo.Endorsements");
        }
    }
}
