using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager= new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            return View(blogManager.GetListWithCategory());
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.Id = id;
            return View(blogManager.GetList(x => x.BlogId==id));
        }
        public IActionResult BlogListByAuthor()
        {

            return View(blogManager.GetListWithCategoryByAuthor(1));
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> list = (from x in categoryManager.GetList()
                                         select new SelectListItem
                                         {
                                            
                                             Value=x.CategoryId.ToString(),
                                             Text=x.CategoryName
                                         }).ToList();
            ViewBag.list=list;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus=true;
                p.AuthorId=1;
                p.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                blogManager.Add(p);
                return RedirectToAction("BlogListByAuthor", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var value = blogManager.GetByID(id);
            blogManager.Delete(value);
            return RedirectToAction("BlogListByAuthor");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            List<SelectListItem> list2 = (from x in categoryManager.GetList()
                                         select new SelectListItem
                                         {

                                             Value=x.CategoryId.ToString(),
                                             Text=x.CategoryName
                                         }).ToList();
            ViewBag.list2=list2;
            var value = blogManager.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Blog p)
        {
            p.AuthorId=1;
            p.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            blogManager.Update(p);
            return RedirectToAction("BlogListByAuthor");
        }
    }
}
