using BlogSite.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogSite.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthorList()
        {
            var jsonAuthors = JsonConvert.SerializeObject(authors);
            return Json(jsonAuthors);
        }
        public IActionResult GetAuthorById(int authorId)
        {
            var findAuthor = authors.FirstOrDefault(x => x.Id == authorId);
            var jsonAuthors = JsonConvert.SerializeObject(findAuthor);
            return Json(jsonAuthors);
        }
        [HttpPost]
        public IActionResult AddAuthor(AuthorClass author)
        {
            authors.Add(author);
            var jsonAuthors = JsonConvert.SerializeObject(author);
            return Json(jsonAuthors);

        }
        public IActionResult DeleteAuthor(int id)
        {
            var author = authors.FirstOrDefault(x => x.Id == id);
            authors.Remove(author);
            return Json(author);
        }
        public IActionResult UpdateAuthor(AuthorClass p)
        {
            var author = authors.FirstOrDefault(x => x.Id == p.Id);
            author.Name=p.Name;
            var jsonauthor = JsonConvert.SerializeObject(p);
            return Json(jsonauthor);


        }
        public static List<AuthorClass> authors = new List<AuthorClass>
        {
            new AuthorClass
            {
                Id=1,Name="Ayşe"
            },
            new AuthorClass
            {
                Id=2,Name="Alperen"
            },
            new AuthorClass
            {
                Id=3,Name="Göktuğ"
            },
        };
    }
}
