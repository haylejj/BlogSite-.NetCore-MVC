using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Author
{
    public class AuthorMessageNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
