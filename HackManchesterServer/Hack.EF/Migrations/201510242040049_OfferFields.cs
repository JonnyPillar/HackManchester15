namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offer", "Text", c => c.String());
            AddColumn("dbo.Offer", "OfferDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Offer", "VideoCallAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Offer", "SubmittedByUserId", c => c.Long(nullable: false));
            AddColumn("dbo.Offer", "QuestionForId", c => c.Long(nullable: false));
            CreateIndex("dbo.Offer", "SubmittedByUserId");
            CreateIndex("dbo.Offer", "QuestionForId");
            AddForeignKey("dbo.Offer", "QuestionForId", "dbo.Question", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Offer", "SubmittedByUserId", "dbo.User", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offer", "SubmittedByUserId", "dbo.User");
            DropForeignKey("dbo.Offer", "QuestionForId", "dbo.Question");
            DropIndex("dbo.Offer", new[] { "QuestionForId" });
            DropIndex("dbo.Offer", new[] { "SubmittedByUserId" });
            DropColumn("dbo.Offer", "QuestionForId");
            DropColumn("dbo.Offer", "SubmittedByUserId");
            DropColumn("dbo.Offer", "VideoCallAvailable");
            DropColumn("dbo.Offer", "OfferDateTime");
            DropColumn("dbo.Offer", "Text");
        }
    }
}
