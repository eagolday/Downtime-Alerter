using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DowntimeAlerter.ApplicationLayer.IServices {
 

    public interface IBaseService<T> {
     

        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T GetBy(Expression<Func<T, bool>> predicate);

        T GetById(Guid id);

        T Add(T entity);

        bool Delete(T entity);

        bool DeleteById(Guid id);
        
        void Edit(T entity);
        
        bool Save();
    }
}
