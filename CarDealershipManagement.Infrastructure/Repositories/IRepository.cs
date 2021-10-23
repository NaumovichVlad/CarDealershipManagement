using CarDealershipManagement.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public interface IRepository<T>
        where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> Take(int rows);
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
