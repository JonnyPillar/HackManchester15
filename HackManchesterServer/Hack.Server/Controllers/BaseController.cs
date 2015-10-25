using System.Web.Mvc;
using Hack.Domain.Interfaces;
using Hack.EF;

namespace Hack.Server.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly HackDbContext HackDbContext;

        protected BaseController(HackDbContext hackDbContext, IApplicationContext applicationContext)
        {
            HackDbContext = hackDbContext;
            ApplicationContext = applicationContext;
        }

        public BaseController()
        {
            
        }

        public IApplicationContext ApplicationContext { get; private set; }
    }
}