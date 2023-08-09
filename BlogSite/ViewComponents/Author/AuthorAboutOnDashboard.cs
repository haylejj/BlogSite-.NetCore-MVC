using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Author
{
    public class AuthorAboutOnDashboard:ViewComponent
    {
        AuthorManager authorManager = new AuthorManager(new EfAuthorRepository());

        private readonly UserManager<AppUser> _userManager;

        public AuthorAboutOnDashboard(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var username = await _userManager.FindByNameAsync(User.Identity.Name);
            var usermail=username.Email;
            ViewBag.v1=username;
            ViewBag.v2=usermail;
            //var usermail = User.Identity.Name;
            //var author = authorManager.GetList().Where(x => x.AuthorMail==usermail).Select(y => y.AuthorId).FirstOrDefault();
            return View();
        }
    }
}
