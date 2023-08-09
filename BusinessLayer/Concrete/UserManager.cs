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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal=userDal;
        }

        public void Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public AppUser GetByID(int id)
        {
           return _userDal.GetById(id);
        }

        public List<AppUser> GetList()
        {
            return _userDal.GetList();
        }

        public List<AppUser> GetList(Expression<Func<AppUser, bool>> filter)
        {
            return _userDal.GetList(filter);
        }

        public void Update(AppUser entity)
        {
            _userDal.Update(entity);
        }
    }
}
