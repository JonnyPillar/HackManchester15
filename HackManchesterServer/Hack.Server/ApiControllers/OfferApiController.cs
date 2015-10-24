using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Hack.Domain.DataContracts.ApiRequests;
using Hack.Domain.DataContracts.ApiResponses;
using Hack.Domain.Entities;
using Hack.Domain.Interfaces;
using Hack.EF;

namespace Hack.Server.ApiControllers
{
    public class OfferApiController : BaseApiController
    {
        public OfferApiController(HackDbContext hackDbContext, IApplicationContext applicationContext)
            : base(hackDbContext, applicationContext)
        {
        }

        [HttpPost]
        [Route("api/Offers/Submit")]
        public IHttpActionResult SubmitOffer(SubmitOfferRequest submitOfferRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var offer = new Offer(submitOfferRequest.Text, DateTime.UtcNow, submitOfferRequest.VideoCallAvailable,
                ApplicationContext.User.UserId, submitOfferRequest.QuestionForId);
            HackDbContext.Offers.Add(offer);
            HackDbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("api/Offers/{id:long}")]
        public IHttpActionResult GetOffersForQuestion(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var offers = HackDbContext.Offers.Where(x => x.QuestionForId == id).ToList();

            var response = new List<OfferForQuestion>();

            foreach (var offer in offers)
            {
                var user = HackDbContext.Users.SingleOrDefault(x => x.Id == offer.SubmittedByUserId);
                string username;
                if (user != null)
                {
                    username = user.Username;
                }
                else
                {
                    return InternalServerError();
                }
                response.Add(new OfferForQuestion(offer.Text, offer.OfferDateTime, username, offer.VideoCallAvailable));
            }

            return Ok(new GetOffersForQuestionResponse(response));
        }
    }
}