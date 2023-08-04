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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal=authorDal;
        }

        public void Add(Author entity)
        {
            _authorDal.Insert(entity);
        }

        public void Delete(Author entity)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthorById(int id)
        {
          return  _authorDal.GetList(x => x.AuthorId==id);
        }

        public Author GetByID(int id)
        {
           return _authorDal.GetById(id);
        }

        public List<Author> GetList()
        {
            return _authorDal.GetList();
        }

        public List<Author> GetList(Expression<Func<Author, bool>> filter)
        {
            return _authorDal.GetList(filter);
        }

        public void Update(Author entity)
        {
            _authorDal.Update(entity);
        }
    }
}
