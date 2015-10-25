using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Hack.Domain.DataContracts.ApiRequests;
using Hack.Domain.Entities;
using Hack.Domain.Interfaces;
using Hack.EF;
using Hack.Server.Attributes;
using QuestionTag = Hack.Domain.Entities.QuestionTag;

namespace Hack.Server.ApiControllers
{
    public class QuestionApiController : BaseApiController
    {
        public QuestionApiController(HackDbContext hackDbContext, IApplicationContext applicationContext)
            : base(hackDbContext, applicationContext)
        {
        }

        [CustomAuthorise]
        [HttpPost]
        [Route("api/Questions/Submit")]
        public IHttpActionResult SubmitQuestion(SubmitQuestionRequest submitQuestionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var questionTags = new List<QuestionTag>();
            foreach (var tag in submitQuestionRequest.QuestionTags)
            {
                var t = HackDbContext.QuestionTags.SingleOrDefault(x => x.Tag.Equals(tag.Name));
                if (t != null)
                {
                    questionTags.Add(t);
                }
            }

            var question = new Question(submitQuestionRequest.Title, submitQuestionRequest.Description, questionTags,
                DateTime.UtcNow, ApplicationContext.User.UserId);
            HackDbContext.Questions.Add(question);
            HackDbContext.SaveChanges();

            return Ok();
        }
    }
}