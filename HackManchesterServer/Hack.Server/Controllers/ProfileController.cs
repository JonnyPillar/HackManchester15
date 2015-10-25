using System.Collections.Generic;
using System.Data.Entity;
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
            var user = HackDbContext.Users.Where(x => x.Token == model.Token).Include(x => x.Endorsements).First();
            return View(new ProjectIndexViewModel(user));
        }

        public ActionResult Detail(int id)
        {
            var user = HackDbContext.Users.Where(x => x.Id == id).Include(x => x.Endorsements).First();
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
            Location = user.Location;
            ProfileImage = user.ProfileImageUrl;
            Endorsements = user.Endorsements.Select(x => new EndorsementItem(x)).ToList();
        }

        public string Location { get; set; }

        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public long Id { get; set; }
        public List<EndorsementItem> Endorsements { get; set; }
    }

    public class EndorsementItem
    {
        public EndorsementItem(Endorsement endorsement)
        {
            Name = endorsement.Tag.Tag;
            Count = endorsement.Count;
        }

        public int Count { get; set; }
        public string Name { get; set; }
    }

    public class ProjectIndexRequestModel
    {
        public string Token { get; set; }
    }
}