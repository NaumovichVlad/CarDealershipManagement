using CarDealershipManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Interfaces
{
    public interface IUsersRepository
    {
        User GetById(int id);
        IQueryable<User> List();
        IQueryable<User> List(Expression<Func<User, bool>> predicate);
        void Insert(User entity);
        void Delete(User entity);
        void Update(User entity);
    }
}
