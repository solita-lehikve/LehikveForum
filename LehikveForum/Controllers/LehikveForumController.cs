using LehikveForum.Data;
using LehikveForum.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace LehikveForum.Controllers
{
    public class LehikveForumController : Controller
    {
        private readonly LehikveForumContext _db;

        public LehikveForumController(LehikveForumContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Topic> objTopicList = _db.Topics;
            return View(objTopicList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Topic topic)
        {
            if(ModelState.IsValid) {
                _db.Topics.Add(topic);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }
    }
}