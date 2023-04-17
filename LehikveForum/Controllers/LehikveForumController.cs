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

        public IActionResult Index()
        {
            IEnumerable<Topic> objTopicList = _db.Topics;
            return View(objTopicList);
        }
    }
}