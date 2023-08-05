using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Author
{
    public class AuthorMessageNotification:ViewComponent
    {
        Message2Manager message2Manager= new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 1;
            return View(message2Manager.GetInboxListByAuthor(id));
        }
    }
}
