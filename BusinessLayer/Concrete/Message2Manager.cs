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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            this.message2Dal=message2Dal;
        }

        public void Add(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public Message2 GetByID(int id)
        {
            return message2Dal.GetById(id);
        }

        public List<Message2> GetInboxListByAuthor(int id)
        {
            return message2Dal.GetListWithMessageByAuthor(id);
        }

        public List<Message2> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetList(Expression<Func<Message2, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Message2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
