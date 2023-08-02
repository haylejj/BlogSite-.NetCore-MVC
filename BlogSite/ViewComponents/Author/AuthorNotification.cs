using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Author
{
    public class AuthorNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
