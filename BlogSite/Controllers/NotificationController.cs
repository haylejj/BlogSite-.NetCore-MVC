using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{

    public class NotificationController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View(notificationManager.GetList());
        }
        public static string FormatTimeAgo(DateTime dateTime)
        {
            TimeSpan timeSince = DateTime.Now - dateTime;

            if (timeSince.TotalSeconds < 60)
            {
                return "şimdi";
            }
            else if (timeSince.TotalMinutes < 60)
            {
                int minutes = (int)timeSince.TotalMinutes;
                return $"{minutes} dakika önce";
            }
            else if (timeSince.TotalHours < 24)
            {
                int hours = (int)timeSince.TotalHours;
                return $"{hours} saat önce";
            }
            else
            {
                int days = (int)timeSince.TotalDays;
                return $"{days} gün önce";
            }
        }

    }
}
