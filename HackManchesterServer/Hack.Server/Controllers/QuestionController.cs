using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hack.Domain.Entities;
using Hack.Domain.Interfaces;
using Hack.EF;

namespace Hack.Server.Controllers
{
    public class QuestionController : BaseController

    {
        public QuestionController(HackDbContext hackDbContext, IApplicationContext applicationContext)
            : base(hackDbContext, applicationContext)
        {
        }

        public ActionResult Details(int id)
        {
            var question = HackDbContext.Questions.First(x => x.Id == id);
            return View(new QuestionDetailViewModel(question));
        }
    }

    public class QuestionDetailViewModel
    {
        public QuestionDetailViewModel(Question question)
        {
            Comments = question.Offers.Select(x => new CommentItem(x)).ToList();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<CommentItem> Comments { get; set; }
        public string DateTimeString { get; set; }
        public string UserName { get; set; }
    }

    public class CommentItem
    {
        public CommentItem(Offer offer)
        {
            Id = offer.Id;
            Content = offer.Text;
            Timestamp = offer.OfferDateTime;
            VideoCallAvailable = offer.VideoCallAvailable;
        }

        public bool VideoCallAvailable { get; set; }

        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}