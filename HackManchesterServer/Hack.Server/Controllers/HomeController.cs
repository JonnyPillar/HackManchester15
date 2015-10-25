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

        public ActionResult Index(string tags)
        {
            if (tags == null)
            {
                var questions = HackDbContext.Questions.ToList().OrderByDescending(x => x.QuestionUploadedDateTime);
                return View(questions.Select(x => new HomeQuestionViewModel(x)).ToList());
            }
            else
            {
            var tagsArray = tags.Split(',');

                var temp = new List<Question>();

                foreach (var tag in tagsArray)
                {
                    if (!HackDbContext.QuestionTags.Any(y => y.Tag == tag)) continue;
                    
                    var sdfsdfds = HackDbContext.QuestionTags.Where(y => y.Tag == tag);
                    var newQuestions = sdfsdfds.Select(x => x.Questions);

                    foreach (var dfsdf in newQuestions)
                    {
                        foreach (var bcvcvb in dfsdf)
                        {
                            temp.Add(bcvcvb);
                        }
                    }
                }

                var questions = temp.OrderByDescending(x => x.QuestionUploadedDateTime);
                return View(questions.Select(x => new HomeQuestionViewModel(x)).ToList());
            }
        }

        public ActionResult Asked(AskedRequesModel model)
        {
            var user = HackDbContext.Users.First(x => x.Token == model.Token);
            var questions = HackDbContext.Questions.Where(x => x.UserId == user.Id).ToList().OrderByDescending(x => x.QuestionUploadedDateTime);
            return View("Index", questions.Select(x => new HomeQuestionViewModel(x)).ToList());
        }

        public ActionResult Answered(AnsweredRequesModel model)
        {
            var user = HackDbContext.Users.First(x => x.Token == model.Token);
            var questions = HackDbContext.Questions.Where(x => x.Offers.Any(y => y.SubmittedByUserId == user.Id)).ToList().OrderByDescending(x => x.QuestionUploadedDateTime);
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
            Title = question.Title.Length > 49 ? question.Title.Substring(0, 50) + "..." : question.Title;
            Description = question.Description.Length > 115 ? question.Description.Substring(0, 115) + "..." : question.Description;
            if (question.QuestionTags.Count >= 1)
            {
                ImageUrl = question.QuestionTags.First().ImageUrl;
            }
            Tags = question.QuestionTags.Select(x => new TagItem(x)).ToList();
            Timestamp = DateHelper.DateTimeGenerator(question.QuestionUploadedDateTime);
            Location = question.Location;
            InYourArea = question.InYourArea;
        }

        public bool InYourArea { get; set; }

        public string Location { get; set; }

        public string Timestamp { get; set; }

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