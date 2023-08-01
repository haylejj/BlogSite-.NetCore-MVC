using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
	[AllowAnonymous]
	public class AuthorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult AuthorNavbarPartial()
		{
            return PartialView();
        }
        public PartialViewResult AuthorFooterPartial()
        {
            return PartialView();
        }
    }
}
