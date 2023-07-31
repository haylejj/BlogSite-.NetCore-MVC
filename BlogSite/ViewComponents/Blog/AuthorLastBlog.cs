using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Blog
{
    public class AuthorLastBlog:ViewComponent
    {
        BlogManager blogManager= new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            id=1;
            return View(blogManager.GetList(x => x.AuthorId==id));
        }
    }
}
