using System.Data.Entity.Migrations;
using System.Linq;
using Hack.Domain;

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
        }
    }
}