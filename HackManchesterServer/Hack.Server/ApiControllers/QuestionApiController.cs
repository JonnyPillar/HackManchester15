using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Hack.Domain.DataContracts.ApiRequests;
using Hack.Domain.DataContracts.ApiResponses;
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

            return Ok(new SubmitQuestionResponse(question.Id));
        }

        [CustomAuthorise]
        [HttpPost]
        [Route("api/Questions/Enter/{id:long}")]
        public IHttpActionResult EnterQuestion(long id)
        {
            var question = HackDbContext.Questions.SingleOrDefault(x => x.Id == id);

            if (question == null)
            {
                return InternalServerError();
            }
            
            question.PeopleEnteredInQuestion = true;
            HackDbContext.SaveChanges();

            return Ok();
        }

        [CustomAuthorise]
        [HttpGet]
        [Route("api/Questions/Poll")]
        public IHttpActionResult PollQuestion()
        {
            var questions = HackDbContext.Questions.Where(x => x.UserId == ApplicationContext.User.UserId && x.PeopleEnteredInQuestion);

            var response = new List<PollQuestion>();

            foreach (var question in questions)
            {
                response.Add(new PollQuestion(question.Id, question.Title, question.Description));
                //question.PeopleEnteredInQuestion = false;
            }
            HackDbContext.SaveChanges();

            return Ok(new PollResponse(response));
        }

        [CustomAuthorise]
        [HttpPost]
        [Route("api/Questions/Leave/{id:long}")]
        public IHttpActionResult LeaveQuestion(long id)
        {
            var question = HackDbContext.Questions.SingleOrDefault(x => x.Id == id);

            if (question == null)
            {
                return InternalServerError();
            }

            question.PeopleEnteredInQuestion = false;
            HackDbContext.SaveChanges();

            return Ok();
        }
    }
}