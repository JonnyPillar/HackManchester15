using System;
using System.ComponentModel.DataAnnotations;

namespace Hack.Domain.DataContracts.ApiRequests
{
    public class SubmitOfferRequest
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime OfferDateTime { get; set; }
        [Required]
        public bool VideoCallAvailable { get; set; }
        [Required]
        public long QuestionForId { get; set; }
    }
}