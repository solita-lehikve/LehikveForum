using DiscussionForum.Data;
using DiscussionForum.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DiscussionForum.Controllers
{
    public class DiscussionForumController : Controller
    {
        private readonly DiscussionForumContext _db;

        public DiscussionForumController(DiscussionForumContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Topic> objTopicList = _db.Topics;
            return View(objTopicList);
        }
    }
}