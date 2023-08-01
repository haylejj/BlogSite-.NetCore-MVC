using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
	public class ContactController : Controller
	{
		ContactManager contactManager= new ContactManager(new EfContactRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
        public IActionResult Index(Contact p)
        {
			p.ContactDate=DateTime.Parse(DateTime.Now.ToShortDateString());
			p.ContactStatus=true;
			contactManager.Add(p);
			return RedirectToAction("Index", "Blog");
        }
    }
}
