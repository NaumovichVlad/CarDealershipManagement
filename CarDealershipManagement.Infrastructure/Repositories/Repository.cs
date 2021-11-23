using CarDealershipManagement.Core.Interfaces;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> 
        where T : EntityBase
    {
        private readonly CarDealershipContext _dbContext;
        public Repository(CarDealershipContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public virtual IQueryable<T> List()
        {
            return _dbContext.Set<T>();
        }
        public virtual IQueryable<T> Take(int rows)
        {
            return _dbContext.Set<T>().Take(rows);
        }
        public virtual IQueryable<T> Skip(int rows)
        {
            return _dbContext.Set<T>().Skip(rows);
        }
        public virtual IQueryable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate);
        }
        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
