using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager= new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return	PartialView();
		}
		[HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
			p.CommentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus=true;
			p.BlogId=7;
			commentManager.Add(p);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            return PartialView(commentManager.GetList(x=>x.BlogId==id));
        }
    }
}
