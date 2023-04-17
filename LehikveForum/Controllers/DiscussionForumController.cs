using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class DiscussionForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}