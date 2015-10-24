using System;
using System.Web.Http;
using Hack.Domain.DataContracts.ApiRequests;
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
    }
}