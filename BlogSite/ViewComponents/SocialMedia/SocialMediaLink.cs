using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.SocialMedia
{
	public class SocialMediaLink:ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
