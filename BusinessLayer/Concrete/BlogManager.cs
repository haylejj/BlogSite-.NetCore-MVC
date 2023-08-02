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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal=blogDal;
        }

        public void Add(Blog entity)
        {
            _blogDal.Insert(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public Blog GetByID(int id)
        {
           return _blogDal.GetById(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetList();
        }

        public List<Blog> GetList(Expression<Func<Blog, bool>> filter)
        {
            return _blogDal.GetList(filter);
        }

        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByAuthor(int id)
        {
            return _blogDal.GetListWithCategoryByAuthor(id);
        }

        public void Update(Blog entity)
        {

            _blogDal.Update(entity);
        }
    }
}
