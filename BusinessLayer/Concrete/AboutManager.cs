using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        EfAboutRepository _aboutRepository;

        public AboutManager(EfAboutRepository aboutRepository)
        {
            _aboutRepository=aboutRepository;
        }

        public void Add(About entity)
        {
            _aboutRepository.Insert(entity);
        }

        public void Delete(About entity)
        {
            _aboutRepository.Delete(entity);
        }

        public About GetByID(int id)
        {
            return _aboutRepository.GetById(id);
        }

        public List<About> GetList()
        {
            return _aboutRepository.GetList();
        }

        public List<About> GetList(Expression<Func<About, bool>> filter)
        {
            return _aboutRepository.GetList(filter);
        }

        public void Update(About entity)
        {
            _aboutRepository.Update(entity);
        }
    }
}
