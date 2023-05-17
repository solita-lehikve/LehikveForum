using LehikveForum.Data;
using LehikveForum.Models;
using LehikveForum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LehikveForum.Controllers
{
    public class TopicPageController : Controller
    {
        private readonly LehikveForumContext _context;
        private readonly ITopicRepository topicRepo;

        public TopicPageController(LehikveForumContext context, ITopicRepository topicRepo)
        {
            _context = context;
            this.topicRepo = topicRepo; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            var topics = topicRepo.GetAll();
            return View(topics);
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

            var topic = _context.Topics.Find(id);

            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
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
            var topic = _context.Topics.Find(id);

            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var topic = _context.Topics.Find(id);

            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}