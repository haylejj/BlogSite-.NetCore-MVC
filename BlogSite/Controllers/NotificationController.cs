using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
