using System.Web.Http;
using Hack.Domain.Interfaces;
using Hack.EF;

namespace Hack.Server.ApiControllers
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly HackDbContext HackDbContext;

        protected BaseApiController(HackDbContext hackDbContext, IApplicationContext applicationContext)
        {
            HackDbContext = hackDbContext;
            ApplicationContext = applicationContext;
        }

        public IApplicationContext ApplicationContext { get; private set; }
    }
}