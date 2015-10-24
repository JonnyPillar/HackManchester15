using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Hack.Domain.DataContracts.ApiResponses;
using Hack.Domain.Interfaces;
using Hack.EF;
using Hack.Server.Attributes;

namespace Hack.Server.ApiControllers
{
    public class QuestionTagController : BaseApiController
    {
        public QuestionTagController(HackDbContext hackDbContext, IApplicationContext applicationContext)
            : base(hackDbContext, applicationContext)
        {
        }

        [CustomAuthorise]
        [HttpGet]
        [Route("api/QuestionTag")]
        public IHttpActionResult GetQuestionTags()
        {
            var questionTags = HackDbContext.QuestionTags.ToList();

            var response = new List<QuestionTag>();

            foreach (var questionTag in questionTags)
            {
                response.Add(new QuestionTag(questionTag.Tag, questionTag.ImageUrl));
            }

            return Ok(new QuestionTagsResponse(response));
        }
    }
}