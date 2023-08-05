using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
  
    public class DashboardController : Controller
    {
        BlogManager blogManager= new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager= new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            ViewBag.v1=blogManager.GetList().Count().ToString();
            ViewBag.v2=blogManager.GetList().Where(x => x.AuthorId==1).Count();
            ViewBag.v3=categoryManager.GetList().Count();
            return View();
        }
    }
}
