using CarDealershipManagement.Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CarDealershipManagement.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetById(string id);
        IQueryable<User> List();
        IQueryable<User> Take(int rows);
        IQueryable<User> List(Expression<Func<User, bool>> predicate);
        void Insert(User entity);
        void Delete(User entity);
        void Update(User entity);
    }
}
