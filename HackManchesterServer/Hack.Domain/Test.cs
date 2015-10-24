using System;


namespace Hack.Domain
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }
    }

    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreateDateTime = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
