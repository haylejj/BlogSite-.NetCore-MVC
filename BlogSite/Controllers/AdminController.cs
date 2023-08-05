using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminNabvarPartial()
        {
            return PartialView();
        }
    }
}
