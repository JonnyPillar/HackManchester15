using System.Linq;
using System.Web.Mvc;
using Hack.Domain.Entities;
using Hack.Domain.Interfaces;
using Hack.EF;

namespace Hack.Server.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(long id = 0)
        {
            var questions = HackDbContext.Questions;
            //var questions = hackDbContext.Questions.Where(x => x.Id == id).ToList();
            return View(questions.Select(x => new HomeQuestionViewModel(x)).ToList());
        }

        public HomeController(HackDbContext hackDbContext, IApplicationContext applicationContext) : base(hackDbContext, applicationContext)
        {
        }
    }

    public class HomeQuestionViewModel
    {
        public HomeQuestionViewModel(Question question)
        {
            Id = question.Id;
        }

        public long Id { get; set; }
    }
}