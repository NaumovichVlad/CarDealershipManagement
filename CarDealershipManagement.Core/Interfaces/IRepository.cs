﻿using CarDealershipManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarDealershipManagement.Core.Interfaces
{
    public interface IRepository<T>
        where T : EntityBase
    {
        T GetById(int id);
        IQueryable<T> List();
        IQueryable<T> Take(int rows);
        IQueryable<T> List(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
