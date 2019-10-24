using DowntimeAlerter.Data.Context.Context;
using DowntimeAlerter.Domain.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DowntimeAlerter.ApplicationLayer.Repository
{
    public  class GenericRepository<T> :IGenericRepository<T> where T : class, new()
    {
       // private readonly DowntimeAlerterDbContext _dbContext;
        protected DbContext DbContext;     
        protected readonly DbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            DbContext = context;
            _dbset = DbContext.Set<T>();
        }

      
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }
        
        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }
        
        public T GetById(Guid id)
        {
            return _dbset.Find(id);
        }        
        public virtual T Add(T entity)
        {
            _dbset.Add(entity);
            return entity;
        }
        
        public virtual int Delete(T entity)
        {
            return SetState(entity, EntityState.Deleted);
        }
        
        public virtual int DeleteById(Guid id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }
        
        public virtual void Edit(T entity)
        {
            _dbset.Update(entity);
        }
        public virtual bool Save()
        {
            return DbContext.SaveChanges() > 0;
        }
        
        protected int SetState(T entity, EntityState state)
        {
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            entry.State = state;
            return DbContext.SaveChanges();
        }
    }
   
}
