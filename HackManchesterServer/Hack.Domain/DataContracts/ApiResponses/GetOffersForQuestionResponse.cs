using System;
using System.Collections.Generic;

namespace Hack.Domain.DataContracts.ApiResponses
{
    public class GetOffersForQuestionResponse
    {
        public GetOffersForQuestionResponse(List<OfferForQuestion> offersForQuestion)
        {
            OffersForQuestion = offersForQuestion;
        }

        public List<OfferForQuestion> OffersForQuestion { get; set; }
    }

    public class OfferForQuestion
    {
        public OfferForQuestion(string text, DateTime submittedDateTime, string submittedByUser, bool videoCallAvailable)
        {
            Text = text;
            SubmittedDateTime = submittedDateTime;
            SubmittedByUser = submittedByUser;
            VideoCallAvailable = videoCallAvailable;
        }

        public string Text { get; set; }
        public DateTime SubmittedDateTime { get; set; }
        public string SubmittedByUser { get; set; }
        public bool VideoCallAvailable { get; set; }
    }
}