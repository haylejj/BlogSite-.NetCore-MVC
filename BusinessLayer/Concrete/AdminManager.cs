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
    public class AdminManager : IAdminService
    {
        IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal=adminDal;
        }

        public void Add(Admin entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
