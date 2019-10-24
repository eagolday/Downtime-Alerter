
using DowntimeAlerter.ApplicationLayer.IServices;
using DowntimeAlerter.ApplicationLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DowntimeAlerter.ApplicationLayer.Services {


    public class BaseService<T> : IBaseService<T> where T : class, new() {

        public IGenericRepository<T> _repository { get; set; }
      
        public BaseService(IGenericRepository<T> repository) {
           _repository = repository;
        }
        public IEnumerable<T> GetAll() {
            var results = _repository.GetAll();
            return results;
        }

  
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) {
            var results = _repository.FindBy(predicate);
            return results;

        }

        public T GetBy(Expression<Func<T, bool>> predicate) {
            var result = _repository.GetBy(predicate);
            return result;
        }
        
        public T GetById(Guid id) {
            return _repository.GetById(id);
        }


        public T Add(T entity) {
            var result = _repository.Add(entity);
            return result;
        }

      
        public bool Delete(T entity) {
            var result = _repository.Delete(entity);
            return result > 0;
        }

 
        public bool DeleteById(Guid id) {
            var result = _repository.DeleteById(id);
            return result > 0;
        }

        public virtual void Edit(T entity) {
            _repository.Edit(entity);
        }


        public bool Save() {
            return _repository.Save();
        }


    }
}
