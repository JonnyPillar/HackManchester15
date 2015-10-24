using System.ComponentModel.DataAnnotations;

namespace Hack.Domain.DataContracts.ApiRequests
{
    public class GetOffersForQuestionRequest
    {
        [Required]
        public long QuestionId { get; set; }
    }
}