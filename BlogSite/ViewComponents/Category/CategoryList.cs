using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogSite.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

		public IViewComponentResult Invoke()
		{
			return View(categoryManager.GetList());
		}
	}
}
