using LehikveForum.Data;
using LehikveForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LehikveForum.Controllers
{
    public class LehikveForumController : Controller
    {
        private readonly LehikveForumContext _context;

        public LehikveForumController(LehikveForumContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {

            IEnumerable<Topic> objTopicList = _context.Topics.Include(p => p.Messages);

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
                _context.Topics.Add(topic);
                _context.SaveChanges();
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
            var topicFromDb = _context.Topics.Find(id);
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
                _context.Topics.Update(topic);
                _context.SaveChanges();
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
            var topicFromDb = _context.Topics.Find(id);
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
            var topicFromDb = _context.Topics.Find(id);

            if (topicFromDb == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topicFromDb);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}