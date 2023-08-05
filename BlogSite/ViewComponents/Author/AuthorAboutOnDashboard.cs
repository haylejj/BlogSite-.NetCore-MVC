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
            var usermail = User.Identity.Name;
            var author = authorManager.GetList().Where(x => x.AuthorMail==usermail).Select(y => y.AuthorId).FirstOrDefault();
            return View(authorManager.GetAuthorById(author));
        }
    }
}
