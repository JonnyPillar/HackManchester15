using System.Linq;
using System.Web.Mvc;
using Hack.Domain.Entities;
using Hack.Domain.Interfaces;
using Hack.EF;

namespace Hack.Server.Controllers
{
    public class ProfileController : BaseController
    {
        public ProfileController(HackDbContext hackDbContext, IApplicationContext applicationContext)
            : base(hackDbContext, applicationContext)
        {
        }

        // GET: Profile
        public ActionResult Index(ProjectIndexRequestModel model)
        {
            var user = HackDbContext.Users.First(x => x.Token == model.Token);
            return View(new ProjectIndexViewModel(user));
        }

        public ActionResult Detail(int id)
        {
            var user = HackDbContext.Users.First(x => x.Id == id);
            return View("Index", new ProjectIndexViewModel(user));
        }
    }

    public class ProjectIndexViewModel
    {
        public ProjectIndexViewModel(User user)
        {
            Id = user.Id;
            Name = user.FullName();
            Bio = user.Bio;
            ProfileImage = user.ProfileImageUrl;
        }

        public string ProfileImage { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public long Id { get; set; }
    }

    public class ProjectIndexRequestModel
    {
        public string Token { get; set; }
    }
}