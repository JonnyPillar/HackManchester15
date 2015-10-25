using System.Data.Entity.Migrations;

namespace Hack.EF.Migrations
{
    public partial class Addeddatatoendosrments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endorsement", "TagId", c => c.Long(false));
            AddColumn("dbo.Endorsement", "UserId", c => c.Long(false));
            AddColumn("dbo.Endorsement", "Count", c => c.Int(false));
            CreateIndex("dbo.Endorsement", "TagId");
            CreateIndex("dbo.Endorsement", "UserId");
            AddForeignKey("dbo.Endorsement", "UserId", "dbo.User", "Id", true);
            AddForeignKey("dbo.Endorsement", "TagId", "dbo.QuestionTag", "Id", true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Endorsement", "TagId", "dbo.QuestionTag");
            DropForeignKey("dbo.Endorsement", "UserId", "dbo.User");
            DropIndex("dbo.Endorsement", new[] {"UserId"});
            DropIndex("dbo.Endorsement", new[] {"TagId"});
            DropColumn("dbo.Endorsement", "Count");
            DropColumn("dbo.Endorsement", "UserId");
            DropColumn("dbo.Endorsement", "TagId");
        }
    }
}