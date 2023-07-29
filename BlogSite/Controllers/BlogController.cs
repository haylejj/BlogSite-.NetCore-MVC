using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager= new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            return View(blogManager.GetListWithCategory());
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.Id = id;
            return View(blogManager.GetList(x => x.BlogId==id));
        }
    }
}
