using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Category
{
    public class CategoryListDashboard:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            return View(categoryManager.GetList());
        }
    }
}
