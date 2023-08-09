using BlogSite.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager=signInManager;
		}

		public IActionResult Index()
		{
			return View();
		}
        //     [HttpPost]
        //     public async Task<IActionResult> Index(Author author)
        //     {
        //Context c = new Context();
        //var data = c.Authors.FirstOrDefault(x => x.AuthorMail==author.AuthorMail && x.AuthorPassword==author.AuthorPassword);
        //if (data!=null)
        //{
        //	var claims = new List<Claim>
        //	{
        //		new Claim(ClaimTypes.Name,author.AuthorMail)
        //	};
        //	var useridentity = new ClaimsIdentity(claims, "a");
        //	ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
        //	await HttpContext.SignInAsync(principal);
        //	return RedirectToAction("Index", "Dashboard");
        //}
        //else
        //{
        //	return View();
        //}
        //     }
        [HttpPost]
        public async Task< IActionResult> Index(UserSingInViewModel p)
        {
            if (ModelState.IsValid) { 
            var result = await _signInManager.PasswordSignInAsync(p.username, p.password,false,true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            }
            return View();
        }
    }
}
