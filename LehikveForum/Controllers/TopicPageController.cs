using LehikveForum.Data;
using LehikveForum.Models;
using LehikveForum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;

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
            var allTopics = topicRepo.GetAll();

            IList<TopicViewModel> topicViewModels = new List<TopicViewModel>();

            foreach (var topic in allTopics)
            {
                int numberOfMessages = topic.Messages.Count;
                DateTime TOLMessage = DateTime.MinValue;

                if (numberOfMessages > 0)
                {
                    TOLMessage = topic.Messages
                        .OrderBy(p => p.CreatedDateTime)
                        .Last()
                        .CreatedDateTime;
                }

                TopicViewModel topicViewModel = new()
                {
                    Id = topic.Id,
                    Header = topic.Header,
                    NumberOfMessages = numberOfMessages,
                    TimeOfLastMessage = TOLMessage
                };

                topicViewModels.Add(topicViewModel);
            }
            return View(topicViewModels);
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
            var user = _context.Users.First();

            if (user == null)
            {
                return View(topic);
            }

            var newTopic = new Topic
            {
                Header = topic.Header,
                User = user
            };

            _context.Topics.Add(newTopic);
            _context.SaveChanges();

            return RedirectToAction("Index");
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
            var topicNew = _context.Topics.Find(topic.Id);

            if (topicNew == null)
            {
                return View(topic);
            }

            topicNew.Header = topic.Header;
            _context.Topics.Update(topicNew);
            _context.SaveChanges();
            return RedirectToAction("Index");
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