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

        public Author GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Author> GetList(Expression<Func<Author, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
