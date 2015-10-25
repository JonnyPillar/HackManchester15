using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hack.Domain.Entities;
using Hack.Domain.Interfaces;
using Hack.EF;

namespace Hack.Server.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(HackDbContext hackDbContext, IApplicationContext applicationContext)
            : base(hackDbContext, applicationContext)
        {
        }

        public ActionResult Index(long id = 0)
        {
            var questions = HackDbContext.Questions.ToList().OrderBy(x => x.QuestionUploadedDateTime);
            return View(questions.Select(x => new HomeQuestionViewModel(x)).ToList());
        }

        public ActionResult Asked(AskedRequesModel model)
        {
            var user = HackDbContext.Users.First(x => x.Token == model.Token);
            var questions = HackDbContext.Questions.Where(x => x.UserId == user.Id).ToList().OrderBy(x => x.QuestionUploadedDateTime);
            return View("Index", questions.Select(x => new HomeQuestionViewModel(x)).ToList());
        }

        public ActionResult Answered(AnsweredRequesModel model)
        {
            var user = HackDbContext.Users.First(x => x.Token == model.Token);
            var questions = HackDbContext.Questions.Where(x => x.Offers.Any(y => y.SubmittedByUserId == user.Id)).ToList().OrderBy(x => x.QuestionUploadedDateTime);
            return View("Index", questions.Select(x => new HomeQuestionViewModel(x)).ToList());
        } 
    }

    public class AnsweredRequesModel
    {
        public string Token { get; set; }
    }

    public class AskedRequesModel
    {
        public string Token { get; set; }
    }

    public class HomeQuestionViewModel
    {
        public HomeQuestionViewModel(Question question)
        {
            Id = question.Id;
            Title = question.Title;
            Description = question.Description;
            if (question.QuestionTags.Count >= 1)
            {
                ImageUrl = question.QuestionTags.First().ImageUrl;
            }
            Tags = question.QuestionTags.Select(x => new TagItem(x)).ToList();
        }

        public HomeQuestionViewModel()
        {
        }

        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TagItem> Tags { get; set; }
        public long Id { get; set; }
    }

    public class TagItem
    {
        public TagItem(QuestionTag questionTag)
        {
            Title = questionTag.Tag;
        }

        public string Title { get; set; }
    }
}