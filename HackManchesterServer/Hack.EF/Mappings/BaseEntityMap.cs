using System.Data.Entity.ModelConfiguration;
using Hack.Domain.Entities;

namespace Hack.EF.Mappings
{
    public abstract class BaseEntityMap<T> : EntityTypeConfiguration<T>
        where T : BaseEntity
    {
        protected BaseEntityMap(string tableName)
        {
            // Table
            this.ToTable(tableName);

            // Primary Key
            this.HasKey(t => t.Id);
        }
    }
}