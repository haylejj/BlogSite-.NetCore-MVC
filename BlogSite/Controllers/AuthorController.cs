using BlogSite.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
	
	public class AuthorController : Controller
	{
		AuthorManager authorManager= new AuthorManager(new EfAuthorRepository());
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v1=usermail;
			var author = authorManager.GetList().Where(x => x.AuthorMail==usermail).Select(y => y.AuthorName).FirstOrDefault();
			ViewBag.v2=author;
			return View();
		}
		public PartialViewResult AuthorNavbarPartial()
		{
            return PartialView();
        }
        public PartialViewResult AuthorFooterPartial()
        {
            return PartialView();
        }
  
        [HttpGet]
		public IActionResult UpdateAuthor()
		{
            var usermail = User.Identity.Name;
 
            var author = authorManager.GetList().Where(x => x.AuthorMail==usermail).Select(y => y.AuthorId).FirstOrDefault();
     
            return View(authorManager.GetByID(author));
		}
 
        [HttpPost]
        public IActionResult Update(Author p)
        {
			AuthorValidator validator=new AuthorValidator();
			ValidationResult result = validator.Validate(p);
			if (result.IsValid)
			{
				authorManager.Update(p);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach(var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
        }

        [HttpGet]
        public IActionResult AuthorAdd()
		{
            return View();
		}

        [HttpPost]
        public IActionResult AuthorAdd(AddProfileImage p2)
        {
			Author author = new Author();
			if (p2.AuthorImage!=null)
			{
				var extension = Path.GetExtension(p2.AuthorImage.FileName);
				var newimagename=Guid.NewGuid()+extension;
				var location=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AuthorImageFiles/", newimagename);
				var stream=new FileStream(location, FileMode.Create);
				p2.AuthorImage.CopyTo(stream);
				author.AuthorImage=newimagename;
			}
			author.AuthorName=p2.AuthorName;
			author.AuthorMail=p2.AuthorMail;
			author.AuthorPassword=p2.AuthorPassword;
			author.AuthorStatus=true;
			author.AuthorAbout=p2.AuthorAbout;
			authorManager.Add(author);
			return RedirectToAction("Index", "Dashboard");
        }
    }
}
