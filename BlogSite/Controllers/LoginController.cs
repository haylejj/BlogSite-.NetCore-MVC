using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Author author)
        {
			Context c = new Context();
			var data = c.Authors.FirstOrDefault(x => x.AuthorMail==author.AuthorMail && x.AuthorPassword==author.AuthorPassword);
			if (data!=null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,author.AuthorMail)
				};
				var useridentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				return View();
			}
        }
    }
}
