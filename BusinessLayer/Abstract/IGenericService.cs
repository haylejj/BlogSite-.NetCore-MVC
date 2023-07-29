using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> filter);
        T GetByID(int id);
    }
}
