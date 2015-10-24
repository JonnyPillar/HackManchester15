using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Hack.Domain.Entities;

namespace Hack.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HackDbContext>
    {
        private readonly bool _pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            var migrator = new DbMigrator(this);
            _pendingMigrations = migrator.GetPendingMigrations().Any();
            if (_pendingMigrations) migrator.Update();
        }

        protected override void Seed(HackDbContext context)
        {
            SeedUsers(context);
            SeedQuestionTags(context);
            SeedQuestions(context);
        }

        private static void SeedUsers(HackDbContext context)
        {
            var user = new User(1, "TestUser", "Password123", "Test", "User");
            context.Users.AddOrUpdate(n => n.Username, user);
            context.SaveChanges();
        }

        private static void SeedQuestionTags(HackDbContext context)
        {
            var questionTags = new List<QuestionTag>
            {
                new QuestionTag(1, "Education",
                    "https://www.dropbox.com/s/wsgdu8toco7vvmx/educational_thumbnail.png?dl=0"),
                new QuestionTag(2, "Electrical",
                    "https://www.dropbox.com/s/kuxc6so0rvaf6py/electrical_thumbnail.png?dl=0"),
                new QuestionTag(3, "Nature", "https://www.dropbox.com/s/jgairrq4djq34ne/nature_thumbnail.png?dl=0"),
                new QuestionTag(4, "Computers"),
                new QuestionTag(5, "Shower"),
                new QuestionTag(6, "Lights"),
                new QuestionTag(7, "Wiring"),
                new QuestionTag(8, "Diy"),
                new QuestionTag(9, "Maths"),
                new QuestionTag(10, "Equations"),
                new QuestionTag(11, "School"),
                new QuestionTag(12, "Tutoring"),
                new QuestionTag(13, "Spiders"),
                new QuestionTag(14, "Bugs"),
                new QuestionTag(15, "Insects"),
                new QuestionTag(16, "UK Nature"),
                new QuestionTag(17, "PIR"),
                new QuestionTag(18, "Wildlife"),
                new QuestionTag(19, "Circuit Board"),
                new QuestionTag(20, "Teacher")
            };

            questionTags.ForEach(q => context.QuestionTags.AddOrUpdate(x => x.Tag, q));
            context.SaveChanges();
        }

        private static void SeedQuestions(HackDbContext context)
        {
            var questionTags = context.QuestionTags;
            var natureTag = questionTags.SingleOrDefault(x => x.Tag.Equals("Nature"));
            var electricTag = questionTags.SingleOrDefault(x => x.Tag.Equals("Electrical"));
            var educationTag = questionTags.SingleOrDefault(x => x.Tag.Equals("Education"));
            var questions = new List<Question>()
            {
                new Question(1, "I would like help identifying this spider I have captured in my house", "I am based in Manchester and I was hoping someone out there can tell me if this spide is poisonous. Any help would be great because I don’t...", DateTime.UtcNow, 1, new List<QuestionTag>()
                {
                    natureTag
                }),
                new Question(2, "I need help connecting a PIR sensor to my outdoor lighting system. If anyone could help", "Currently I have an outdoor light that is working on an indoor switch and it is bugging me that I am wasiting energy when I turn on the kitchen...", DateTime.UtcNow, 1, new List<QuestionTag>()
                {
                    electricTag
                }),
                new Question(3, "Any maths tutors or anyone whos really good at maths can help me with my school work please", "So I am currently having problems solving this question that is in my maths test exam. I was wondering if someone is able to help me solve...", DateTime.UtcNow, 1, new List<QuestionTag>()
                {
                    educationTag
                }),
                new Question(4, "A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring", "which was created for the bliss of souls like mine. I am so happy, my dear friend, so absorbed in the exquisit", DateTime.UtcNow, 1, new List<QuestionTag>()
                {
                    natureTag
                })
            };

            questions.ForEach(q => context.Questions.AddOrUpdate(x => x.Id, q));
            context.SaveChanges();
        }
    }
}