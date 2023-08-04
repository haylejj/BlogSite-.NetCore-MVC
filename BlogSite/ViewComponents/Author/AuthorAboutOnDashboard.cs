using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Author
{
    public class AuthorAboutOnDashboard:ViewComponent
    {
        AuthorManager authorManager = new AuthorManager(new EfAuthorRepository());
        public IViewComponentResult Invoke()
        {
            return View(authorManager.GetAuthorById(1));
        }
    }
}
