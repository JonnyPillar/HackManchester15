namespace Hack.Domain.DataContracts.ApiResponses
{
    public class SubmitQuestionResponse
    {
        public SubmitQuestionResponse(long questionId)
        {
            QuestionId = questionId;
        }

        public long QuestionId { get; set; }
    }
}