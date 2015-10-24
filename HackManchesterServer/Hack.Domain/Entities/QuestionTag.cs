using System.Collections;
using System.Collections.Generic;

namespace Hack.Domain.Entities
{
    public class QuestionTag : BaseEntity
    {
        public QuestionTag()
        {
            
        }

        public QuestionTag(long id, string tag, string imageUrl) : base(id)
        {
            Tag = tag;
            ImageUrl = imageUrl;
        }

        public QuestionTag(long id, string tag) : base(id)
        {
            Tag = tag;
        }

        public string Tag { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}