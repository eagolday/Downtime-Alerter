using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DowntimeAlerter.ApplicationLayer.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
            IEnumerable<T> GetAll();
            IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
            T GetBy(Expression<Func<T, bool>> predicate);
            T GetById(Guid id);
            T Add(T entity);
            int Delete(T entity);
            int DeleteById(Guid id);
            void Edit(T entity);
            bool Save();
        
    }
}
