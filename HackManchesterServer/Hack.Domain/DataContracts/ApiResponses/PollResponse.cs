using System.Collections.Generic;

namespace Hack.Domain.DataContracts.ApiResponses
{
    public class PollResponse
    {
        public PollResponse(List<PollQuestion> pollQuestions)
        {
            PollQuestions = pollQuestions;
        }

        public List<PollQuestion> PollQuestions { get; set; }
    }

    public class PollQuestion
    {
        public PollQuestion(long id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}