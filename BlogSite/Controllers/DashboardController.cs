using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
