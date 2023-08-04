using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            this.notificationDal=notificationDal;
        }

        public void Add(Notification entity)
        {
            notificationDal.Insert(entity);
        }

        public void Delete(Notification entity)
        {
            notificationDal.Delete(entity);
        }

        public Notification GetByID(int id)
        {
            return  notificationDal.GetById(id);
        }

        public List<Notification> GetList()
        {
            return notificationDal.GetList();
        }

        public List<Notification> GetList(Expression<Func<Notification, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification entity)
        {
            notificationDal.Update(entity);
        }
    }
}
