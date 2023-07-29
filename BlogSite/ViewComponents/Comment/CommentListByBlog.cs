using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager commentManager= new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            return View(commentManager.GetList(x=>x.BlogId==id));
        }
    }
}
