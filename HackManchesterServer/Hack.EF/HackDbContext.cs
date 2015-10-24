using System.Data.Entity;
using Hack.Domain;

namespace Hack.EF
{
    internal class HackDbContext : DbContext
    {
        public HackDbContext() : base("HackDbContext")
        {
        }

        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
