using System.Data.Entity;
using Hack.Domain.Entities;
using Hack.EF.Mappings;

namespace Hack.EF
{
    public class HackDbContext : DbContext
    {
        public HackDbContext() : base("HackDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Endorsement> Endorsements { get; set; }
        public virtual DbSet<QuestionTag> QuestionTags { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddModelBuilderConfigurations(modelBuilder);
        }

        private void AddModelBuilderConfigurations(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new QuestionTagMap());
            modelBuilder.Configurations.Add(new EndorsementMap());
            modelBuilder.Configurations.Add(new OfferMap());
        }
    }
}