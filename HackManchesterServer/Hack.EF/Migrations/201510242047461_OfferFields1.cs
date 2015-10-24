namespace Hack.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferFields1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offer", "SubmittedByUserId", "dbo.User");
            AddForeignKey("dbo.Offer", "SubmittedByUserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offer", "SubmittedByUserId", "dbo.User");
            AddForeignKey("dbo.Offer", "SubmittedByUserId", "dbo.User", "Id", cascadeDelete: false);
        }
    }
}
