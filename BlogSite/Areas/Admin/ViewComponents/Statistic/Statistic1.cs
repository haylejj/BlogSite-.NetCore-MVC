using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BlogSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1=c.Blogs.Count();
            ViewBag.v2=c.Contacts.Count();
            @ViewBag.v3=c.Comments.Count();

            //string api = "3ecda35bc7f3c5570011d1c14a551c25";
            //string connection = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=tr&units=metric&appid=" + api;
            //XDocument document = XDocument.Load(connection);
            //ViewBag.v4=document.Descendants("temperature").ElementAt(0).Attribute("Value").Value;
            return View();
        }
    }
}
