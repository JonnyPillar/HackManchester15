using System.Data.Entity;
using Hack.Domain.Entities;

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
            //modelBuilder.Entity<User>().HasMany(x=>x.)
        }
    }
}