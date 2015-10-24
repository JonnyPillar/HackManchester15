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
    }
}