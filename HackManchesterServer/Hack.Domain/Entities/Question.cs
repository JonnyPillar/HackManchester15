using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Hack.Domain.Entities
{
    public class Question : BaseEntity
    {
        public Question()
        {
            QuestionTags = new List<QuestionTag>();
        }

        public Question(long id, string title, string description, DateTime questionUploadedDateTime, long userId, List<QuestionTag> questionTags ) : base(id)
        {
            Title = title;
            Description = description;
            QuestionUploadedDateTime = questionUploadedDateTime;
            UserId = userId;
            QuestionTags = questionTags;
        }

        public Question(string title, string description, List<QuestionTag> questionTags, DateTime questionUploadedDateTime, long userId)
        {
            Title = title;
            Description = description;
            QuestionTags = questionTags;
            QuestionUploadedDateTime = questionUploadedDateTime;
            UserId = userId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime QuestionUploadedDateTime { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public virtual ICollection<QuestionTag> QuestionTags { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}