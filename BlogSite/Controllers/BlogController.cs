using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Controllers
{
    
    public class BlogController : Controller
    {
        Context c = new Context();
        private readonly UserManager<AppUser> _userManager;
        BlogManager blogManager= new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        AuthorManager authorManager = new AuthorManager(new EfAuthorRepository());

        public BlogController(UserManager<AppUser> userManager)
        {
            _userManager=userManager;
        }

        public IActionResult Index()
        {
            return View(blogManager.GetListWithCategory());
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.Id = id;
            return View(blogManager.GetList(x => x.BlogId==id));
        }
        public async Task< IActionResult> BlogListByAuthor()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var id=c.Authors.Where(x=>x.AuthorId==user.Id).Select(x=>x.AuthorId).FirstOrDefault();

            return View(blogManager.GetListWithCategoryByAuthor(id));
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
            var usermail = User.Identity.Name;

            var author = authorManager.GetList().Where(x => x.AuthorMail==usermail).Select(y => y.AuthorId).FirstOrDefault();
            BlogValidator validationRules = new BlogValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus=true;
                p.AuthorId=author;
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
            var usermail = User.Identity.Name;

            var author = authorManager.GetList().Where(x => x.AuthorMail==usermail).Select(y => y.AuthorId).FirstOrDefault();
            p.AuthorId=author;
            p.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            blogManager.Update(p);
            return RedirectToAction("BlogListByAuthor");
        }
    }
}
