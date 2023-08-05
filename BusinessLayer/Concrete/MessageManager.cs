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
    public class MessageManager : IMessageService
    {
        IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal=messageDal;
        }

        public void Add(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetList()
        {
            return messageDal.GetList();
        }

        public List<Message> GetList(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListByAuthor(string mail)
        {
            return messageDal.GetList(x => x.Receiver==mail);
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
