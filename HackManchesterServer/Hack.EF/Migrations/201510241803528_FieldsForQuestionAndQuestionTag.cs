namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldsForQuestionAndQuestionTag : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Endorsements", newName: "Endorsement");
            RenameTable(name: "dbo.Offers", newName: "Offer");
            RenameTable(name: "dbo.Questions", newName: "Question");
            RenameTable(name: "dbo.QuestionTags", newName: "QuestionTag");
            RenameTable(name: "dbo.Users", newName: "User");
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
            
            AddColumn("dbo.Question", "Title", c => c.String());
            AddColumn("dbo.Question", "Description", c => c.String());
            AddColumn("dbo.Question", "QuestionUploadedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Question", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.QuestionTag", "Tag", c => c.String());
            AddColumn("dbo.QuestionTag", "ImageUrl", c => c.String());
            CreateIndex("dbo.Question", "UserId");
            AddForeignKey("dbo.Question", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "UserId", "dbo.User");
            DropForeignKey("dbo.QuestionQuestionTag", "QuestionTagId", "dbo.QuestionTag");
            DropForeignKey("dbo.QuestionQuestionTag", "QuestionId", "dbo.Question");
            DropIndex("dbo.QuestionQuestionTag", new[] { "QuestionTagId" });
            DropIndex("dbo.QuestionQuestionTag", new[] { "QuestionId" });
            DropIndex("dbo.Question", new[] { "UserId" });
            DropColumn("dbo.QuestionTag", "ImageUrl");
            DropColumn("dbo.QuestionTag", "Tag");
            DropColumn("dbo.Question", "UserId");
            DropColumn("dbo.Question", "QuestionUploadedDateTime");
            DropColumn("dbo.Question", "Description");
            DropColumn("dbo.Question", "Title");
            DropTable("dbo.QuestionQuestionTag");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.QuestionTag", newName: "QuestionTags");
            RenameTable(name: "dbo.Question", newName: "Questions");
            RenameTable(name: "dbo.Offer", newName: "Offers");
            RenameTable(name: "dbo.Endorsement", newName: "Endorsements");
        }
    }
}
