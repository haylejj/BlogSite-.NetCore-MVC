using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        public IActionResult Index()
        {
            return View(message2Manager.GetInboxListByAuthor(2));
        }
        public IActionResult MessageDetails(int id)
        {
            return View(message2Manager.GetByID(id));
        }
    }
}
