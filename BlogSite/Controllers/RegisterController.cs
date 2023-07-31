using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class RegisterController : Controller
    {
        AuthorManager authorManager= new AuthorManager(new EfAuthorRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Author author)
        {
            AuthorValidator validationRules = new AuthorValidator();
            ValidationResult result=validationRules.Validate(author);
            if (result.IsValid)
            {
                author.AuthorStatus=true;
                authorManager.Add(author);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
