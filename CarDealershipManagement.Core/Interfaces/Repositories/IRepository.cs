using CarDealershipManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarDealershipManagement.Core.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс для взаимодействия с репозиториями
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
        where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> Take(int rows);
        IEnumerable<T> Skip(int rows);
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

        T GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> ListWithIncludes(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetRangeWithIncludes(int startIndex, int endIndex,
            params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> ListWithIncludes(params Expression<Func<T, object>>[] includeProperties);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        int GetCount();
    }
}
