using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
		public PartialViewResult PartialAddComment()
		{
			return	PartialView();
		}
        public PartialViewResult CommentListByBlog(int id)
        {
            return PartialView(commentManager.GetList(x=>x.BlogId==id));
        }
    }
}
