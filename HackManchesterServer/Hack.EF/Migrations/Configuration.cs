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
            SeedOffers(context);
            SeedEndorsements(context);
        }

        private void SeedEndorsements(HackDbContext context)
        {
            context.Endorsements.AddOrUpdate(new Endorsement
            {
                Id = 1,
                Count = 10,
                UserId = 1,
                TagId = 1
            });
            context.Endorsements.AddOrUpdate(new Endorsement
            {
                Id = 2,
                Count = 10,
                UserId = 1,
                TagId = 2
            });

            context.SaveChanges();
        }

        private static void SeedUsers(HackDbContext context)
        {
            var users = new List<User>
            {
                new User(1, "JonnyP", "Password123", "Jonny", "Pillar")
                {
                    Bio =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent massa nulla, facilisis ut nulla eget, condimentum vulputate tortor. Curabitur nec ipsum augue. Ut volutpat scelerisque dolor eget ultricies. Nulla condimentum mauris a tellus pulvinar sodales. Aliquam venenatis eros ac mauris tincidunt lacinia. Aenean lectus purus, pharetra a feugiat et, sodales ut nisi. Pellentesque tincidunt ipsum ut vulputate scelerisque. Donec malesuada, tortor in lobortis sagittis, magna dolor cursus dui, a feugiat felis augue nec enim. Nam at pulvinar dui. Nam vitae ligula sodales, porta orci id, malesuada ipsum. Ut eget mi a odio imperdiet pharetra sit amet sit amet elit. Etiam ligula elit, pretium nec semper ut, sagittis in diam. Vivamus quam leo, lacinia non orci sed, sodales tempus neque. Mauris interdum dictum mi, ac ornare justo. Praesent pharetra enim mattis mi gravida fringilla. Phasellus et malesuada mauris."
                    ,
                    ProfileImageUrl = "http://api.randomuser.me/portraits/women/39.jpg"
                },
                new User(2, "StuartC", "Password123", "Stuart", "Campbell")
                {
                    Bio =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent massa nulla, facilisis ut nulla eget, condimentum vulputate tortor. Curabitur nec ipsum augue. Ut volutpat scelerisque dolor eget ultricies. Nulla condimentum mauris a tellus pulvinar sodales. Aliquam venenatis eros ac mauris tincidunt lacinia. Aenean lectus purus, pharetra a feugiat et, sodales ut nisi. Pellentesque tincidunt ipsum ut vulputate scelerisque. Donec malesuada, tortor in lobortis sagittis, magna dolor cursus dui, a feugiat felis augue nec enim. Nam at pulvinar dui. Nam vitae ligula sodales, porta orci id, malesuada ipsum. Ut eget mi a odio imperdiet pharetra sit amet sit amet elit. Etiam ligula elit, pretium nec semper ut, sagittis in diam. Vivamus quam leo, lacinia non orci sed, sodales tempus neque. Mauris interdum dictum mi, ac ornare justo. Praesent pharetra enim mattis mi gravida fringilla. Phasellus et malesuada mauris."
                    ,
                    ProfileImageUrl = "https://randomuser.me/api/portraits/med/women/40.jpg"
                },
                new User(3, "JigzL", "Password123", "Jigz", "Lad")
                {
                    Bio =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent massa nulla, facilisis ut nulla eget, condimentum vulputate tortor. Curabitur nec ipsum augue. Ut volutpat scelerisque dolor eget ultricies. Nulla condimentum mauris a tellus pulvinar sodales. Aliquam venenatis eros ac mauris tincidunt lacinia. Aenean lectus purus, pharetra a feugiat et, sodales ut nisi. Pellentesque tincidunt ipsum ut vulputate scelerisque. Donec malesuada, tortor in lobortis sagittis, magna dolor cursus dui, a feugiat felis augue nec enim. Nam at pulvinar dui. Nam vitae ligula sodales, porta orci id, malesuada ipsum. Ut eget mi a odio imperdiet pharetra sit amet sit amet elit. Etiam ligula elit, pretium nec semper ut, sagittis in diam. Vivamus quam leo, lacinia non orci sed, sodales tempus neque. Mauris interdum dictum mi, ac ornare justo. Praesent pharetra enim mattis mi gravida fringilla. Phasellus et malesuada mauris."
                    ,
                    ProfileImageUrl = "https://randomuser.me/api/portraits/med/men/67.jpg"
                },
                new User(4, "EmmaS", "Password123", "Emma", "Smith")
                {
                    Bio =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent massa nulla, facilisis ut nulla eget, condimentum vulputate tortor. Curabitur nec ipsum augue. Ut volutpat scelerisque dolor eget ultricies. Nulla condimentum mauris a tellus pulvinar sodales. Aliquam venenatis eros ac mauris tincidunt lacinia. Aenean lectus purus, pharetra a feugiat et, sodales ut nisi. Pellentesque tincidunt ipsum ut vulputate scelerisque. Donec malesuada, tortor in lobortis sagittis, magna dolor cursus dui, a feugiat felis augue nec enim. Nam at pulvinar dui. Nam vitae ligula sodales, porta orci id, malesuada ipsum. Ut eget mi a odio imperdiet pharetra sit amet sit amet elit. Etiam ligula elit, pretium nec semper ut, sagittis in diam. Vivamus quam leo, lacinia non orci sed, sodales tempus neque. Mauris interdum dictum mi, ac ornare justo. Praesent pharetra enim mattis mi gravida fringilla. Phasellus et malesuada mauris."
                    ,
                    ProfileImageUrl = "https://randomuser.me/api/portraits/med/men/7.jpg"
                }
            };

            users.ForEach(q => context.Users.AddOrUpdate(x => x.Username, q));
            context.SaveChanges();
        }

        private static void SeedQuestionTags(HackDbContext context)
        {
            var questionTags = new List<QuestionTag>
            {
                new QuestionTag(1, "Education",
                    "http://jonnypillar.co.uk/educational_thumbnail.png"),
                new QuestionTag(2, "Electrical",
                    "http://jonnypillar.co.uk/electrical_thumbnail.png"),
                new QuestionTag(3, "Nature", "http://jonnypillar.co.uk/nature_thumbnail.png"),
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
            var questions = new List<Question>
            {
                new Question(1, "I would like help identifying this spider I have captured in my house",
                    "I am based in Manchester and I was hoping someone out there can tell me if this spide is poisonous. Any help would be great because I don’t...",
                    DateTime.UtcNow, 1, new List<QuestionTag>
                    {
                        natureTag
                    }),
                new Question(2,
                    "I need help connecting a PIR sensor to my outdoor lighting system. If anyone could help",
                    "Currently I have an outdoor light that is working on an indoor switch and it is bugging me that I am wasiting energy when I turn on the kitchen...",
                    DateTime.UtcNow, 1, new List<QuestionTag>
                    {
                        electricTag
                    })
                {
                    Location = "London"
                },
                new Question(3,
                    "Any maths tutors or anyone whos really good at maths can help me with my school work please",
                    "So I am currently having problems solving this question that is in my maths test exam. I was wondering if someone is able to help me solve...",
                    DateTime.UtcNow, 1, new List<QuestionTag>
                    {
                        educationTag
                    }),
                new Question(4,
                    "A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring",
                    "which was created for the bliss of souls like mine. I am so happy, my dear friend, so absorbed in the exquisit",
                    DateTime.UtcNow, 1, new List<QuestionTag>
                    {
                        natureTag
                    }){
                    Location = "Paris"
                }
            };

            questions.ForEach(q => context.Questions.AddOrUpdate(x => x.Id, q));
            context.SaveChanges();
        }

        private static void SeedOffers(HackDbContext context)
        {
            var offers = new List<Offer>
            {
                new Offer(1, "I can help I know about spiders, video call and show me", DateTime.UtcNow, true, 2, 1),
                new Offer(2, "I think I can help here", DateTime.UtcNow, false, 3, 1),
                new Offer(3, "Send a photo and I can identify", DateTime.UtcNow, false, 4, 1)
            };

            offers.ForEach(q => context.Offers.AddOrUpdate(x => x.Id, q));
            context.SaveChanges();
        }
    }
}