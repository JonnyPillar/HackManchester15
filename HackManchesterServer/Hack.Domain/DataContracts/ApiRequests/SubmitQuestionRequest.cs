using System.Collections.Generic;

namespace Hack.Domain.DataContracts.ApiRequests
{
    public class SubmitQuestionRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuestionTag> QuestionTags { get; set; }
    }

    public class QuestionTag
    {
        public string Name { get; set; }
    }
}