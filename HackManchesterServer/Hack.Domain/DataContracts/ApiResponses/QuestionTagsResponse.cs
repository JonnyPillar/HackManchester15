using System.Collections.Generic;

namespace Hack.Domain.DataContracts.ApiResponses
{
    public class QuestionTagsResponse
    {
        public QuestionTagsResponse(List<QuestionTag> questionTags)
        {
            QuestionTags = questionTags;
        }

        public List<QuestionTag> QuestionTags { get; set; }
    }

    public class QuestionTag
    {
        public QuestionTag(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}