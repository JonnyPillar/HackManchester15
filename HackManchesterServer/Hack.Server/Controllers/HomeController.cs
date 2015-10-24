using System.Linq;
using System.Web.Mvc;
using Hack.Domain.Entities;
using Hack.EF;

namespace Hack.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly HackDbContext _hackDbContext = new HackDbContext();

        public ActionResult Index(long id = 0)
        {
            var questions = _hackDbContext.Questions;
            //var questions = hackDbContext.Questions.Where(x => x.Id == id).ToList();
            return View(questions.Select(x => new HomeQuestionViewModel(x)).ToList());
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