using System.Collections;
using System.Collections.Generic;

namespace Hack.Domain.Entities
{
    public class QuestionTag : BaseEntity
    {
        public string Tag { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}