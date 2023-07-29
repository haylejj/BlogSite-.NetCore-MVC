using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class,new()
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        List<T> GetList(Expression<Func<T,bool>> filter);
        T GetById(int id);
    }
}
