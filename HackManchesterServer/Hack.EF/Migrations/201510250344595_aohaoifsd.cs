namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aohaoifsd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endorsement",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TagId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionTag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QuestionTag",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Tag = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        QuestionUploadedDateTime = c.DateTime(nullable: false),
                        UserId = c.Long(nullable: false),
                        PeopleEnteredInQuestion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Offer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        OfferDateTime = c.DateTime(nullable: false),
                        VideoCallAvailable = c.Boolean(nullable: false),
                        SubmittedByUserId = c.Long(nullable: false),
                        QuestionForId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionForId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.SubmittedByUserId)
                .Index(t => t.SubmittedByUserId)
                .Index(t => t.QuestionForId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Forename = c.String(),
                        Surname = c.String(),
                        Token = c.String(),
                        Bio = c.String(),
                        ProfileImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionQuestionTag",
                c => new
                    {
                        QuestionId = c.Long(nullable: false),
                        QuestionTagId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.QuestionTagId })
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionTag", t => t.QuestionTagId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.QuestionTagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endorsement", "TagId", "dbo.QuestionTag");
            DropForeignKey("dbo.Question", "UserId", "dbo.User");
            DropForeignKey("dbo.QuestionQuestionTag", "QuestionTagId", "dbo.QuestionTag");
            DropForeignKey("dbo.QuestionQuestionTag", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Offer", "SubmittedByUserId", "dbo.User");
            DropForeignKey("dbo.Endorsement", "UserId", "dbo.User");
            DropForeignKey("dbo.Offer", "QuestionForId", "dbo.Question");
            DropIndex("dbo.QuestionQuestionTag", new[] { "QuestionTagId" });
            DropIndex("dbo.QuestionQuestionTag", new[] { "QuestionId" });
            DropIndex("dbo.Offer", new[] { "QuestionForId" });
            DropIndex("dbo.Offer", new[] { "SubmittedByUserId" });
            DropIndex("dbo.Question", new[] { "UserId" });
            DropIndex("dbo.Endorsement", new[] { "UserId" });
            DropIndex("dbo.Endorsement", new[] { "TagId" });
            DropTable("dbo.QuestionQuestionTag");
            DropTable("dbo.User");
            DropTable("dbo.Offer");
            DropTable("dbo.Question");
            DropTable("dbo.QuestionTag");
            DropTable("dbo.Endorsement");
        }
    }
}
