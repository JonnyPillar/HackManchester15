using System.Data.Entity;
using Hack.Domain;
using Hack.Domain.Entities;

namespace Hack.EF
{
    internal class HackDbContext : DbContext
    {
        public HackDbContext() : base("HackDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
