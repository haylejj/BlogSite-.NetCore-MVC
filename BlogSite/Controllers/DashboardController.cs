using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
  
    public class DashboardController : Controller
    {
        BlogManager blogManager= new BlogManager(new EfBlogRepository());

        private readonly UserManager<AppUser> _userManager;

        CategoryManager categoryManager= new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }

        public IActionResult Index()
        {

            var username2 = User.Identity.Name;
            ViewBag.v1=blogManager.GetList().Count().ToString();
            var usermail=c.Users.Where(x => x.UserName==username2).Select(y => y.Email).FirstOrDefault();
            var authorid=c.Authors.Where(x=>x.AuthorMail==usermail).Select(y=>y.AuthorId).FirstOrDefault();
            ViewBag.v2=c.Blogs.Where(x => x.AuthorId==authorid).Count();
            ViewBag.v3=categoryManager.GetList().Count();
            return View();
        }
    }
}
