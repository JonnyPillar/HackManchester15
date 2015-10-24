using System;

namespace Hack.Domain.Entities
{
    public class Offer : BaseEntity
    {
        public Offer()
        {
            
        }

        public Offer(long id, string text, DateTime offerDateTime, bool videoCallAvailable, long submittedByUserId, long questionForId) : base(id)
        {
            Text = text;
            OfferDateTime = offerDateTime;
            VideoCallAvailable = videoCallAvailable;
            SubmittedByUserId = submittedByUserId;
            QuestionForId = questionForId;
        }

        public string Text { get; set; }
        public DateTime OfferDateTime { get; set; }
        public bool VideoCallAvailable { get; set; }

        public User SubmittedByUser { get; set; }
        public long SubmittedByUserId { get; set; }

        public Question QuestionFor { get; set; }
        public long QuestionForId { get; set; }
    }
}