namespace Hack.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            
        }

        public BaseEntity(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}