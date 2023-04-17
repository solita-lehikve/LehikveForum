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



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }
            var topicFromDb = _db.Topics.Find(id);
            //var topicFromDbFirst = _db.Topics.FirstOrDefault(x => x.Id == id);
            //var topicFromDbSingle = _db.Topics.SingleOrDefault(x => x.Id == id);

            if (topicFromDb == null)
            {
                return NotFound();
            }

            return View(topicFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Topic topic)
        {
            if (ModelState.IsValid)
            {
                _db.Topics.Update(topic);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var topicFromDb = _db.Topics.Find(id);
            //var topicFromDbFirst = _db.Topics.FirstOrDefault(x => x.Id == id);
            //var topicFromDbSingle = _db.Topics.SingleOrDefault(x => x.Id == id);

            if (topicFromDb == null)
            {
                return NotFound();
            }

            return View(topicFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var topicFromDb = _db.Topics.Find(id);

            if (topicFromDb == null)
            {
                return NotFound();
            }

            _db.Topics.Remove(topicFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}