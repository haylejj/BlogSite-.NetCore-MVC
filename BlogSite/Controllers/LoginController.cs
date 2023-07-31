using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
