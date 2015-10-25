namespace Hack.Domain.Entities
{
    public class Endorsement : BaseEntity
    {
        public long TagId { get; set; }
        public long UserId { get; set; }
        public int Count { get; set; }

        public virtual User User { get; set; }
        public virtual QuestionTag Tag { get; set; }
    }
}