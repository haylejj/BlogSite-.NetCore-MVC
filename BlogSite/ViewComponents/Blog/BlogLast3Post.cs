using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Blog
{
	public class BlogLast3Post:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            return View(blogManager.GetList().OrderBy(x => x.BlogId).Take(3).ToList());
        }
    }
}
