using BlogSite.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
	
	public class AuthorController : Controller
	{
		AuthorManager authorManager= new AuthorManager(new EfAuthorRepository());
		UserManager userManager= new UserManager(new EfUserRepository());
		private readonly UserManager<AppUser> _userManager;

		public AuthorController(UserManager<AppUser> userManager)
		{
			_userManager=userManager;
		}

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
		public async Task< IActionResult> UpdateAuthor()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail=values.Email;
            model.namesurname=values.NameSurname;
            model.imageurl=values.ImageUrl;
			model.username=values.UserName;
            return View(model);
		}
 
        [HttpPost]
        public async Task< IActionResult> Update(UserUpdateViewModel model)
        {
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.Email=model.mail;
			values.NameSurname=model.namesurname;
			values.PasswordHash= _userManager.PasswordHasher.HashPassword(values, model.password);
            values.ImageUrl=model.imageurl;
			var result=await _userManager.UpdateAsync(values);
			return RedirectToAction("Index", "Dashboard");
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
