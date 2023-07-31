using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
	public class NewsLetterController : Controller
	{
		NewsletterManager _newsletterManager= new NewsletterManager(new EfNewsletterRepository());
		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
			p.MailStatus=true;
			_newsletterManager.Insert(p);
			return PartialView(p);
        }
    }
}
