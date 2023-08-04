using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents.Notification
{
    public class NotificationList:ViewComponent
    {
        NotificationManager notificationManager= new NotificationManager(new EfNotificationRepository());

        public IViewComponentResult Invoke()
        {
            return View(notificationManager.GetList());
        }
    }
}
