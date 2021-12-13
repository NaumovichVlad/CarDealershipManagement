using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Общий класс для репозиториев
    /// </summary>
    /// <typeparam name="T">Класс модели базы данных</typeparam>
    public abstract class Repository<T> : IRepository<T> 
        where T : EntityBase
    {
        private readonly CarDealershipContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(CarDealershipContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int GetCount()
        {
            return _dbSet.Count();
        }
        public virtual IEnumerable<T> List()
        {
            return _dbSet.AsEnumerable();
        }
        public virtual IEnumerable<T> Take(int rows)
        {
            return _dbSet.Take(rows).AsEnumerable();
        }
        public virtual IEnumerable<T> Skip(int rows)
        {
            return _dbSet.Skip(rows).AsEnumerable();
        }
        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsEnumerable();
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
        public T GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).First(t => t.Id == id);
        }

        public virtual IEnumerable<T> GetRangeWithIncludes(int startIndex, int endIndex, 
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Skip(startIndex).Take(endIndex - startIndex).AsEnumerable();
        }
        public virtual IEnumerable<T> ListWithIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).AsEnumerable();
        }
        public virtual IEnumerable<T> ListWithIncludes(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).Where(predicate);
        }
        private  IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
