﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1=c.Admins.Where(x => x.AdminId==1).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2=c.Admins.Where(c => c.AdminId==1).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.v3=c.Admins.Where(c => c.AdminId==1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
