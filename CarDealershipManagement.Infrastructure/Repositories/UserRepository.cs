using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarDealershipContext _dbContext;
        public UserRepository(CarDealershipContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(User entity)
        {
            _dbContext.Set<User>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public User GetById(string id)
        {
            return _dbContext.Set<User>().Find(id);
        }

        public void Insert(User entity)
        {
            _dbContext.Set<User>().Add(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<User> List()
        {
            return _dbContext.Set<User>().AsQueryable();
        }

        public IQueryable<User> List(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Set<User>()
                .Where(predicate).AsQueryable();
        }

        public IQueryable<User> Take(int rows)
        {
            return _dbContext.Set<User>().Take(rows).AsQueryable();
        }

        public void Update(User entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
