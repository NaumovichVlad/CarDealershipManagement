using AutoMapper;
using CarDealershipManagement.Core.Interfaces;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using CarDealershipManagement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CarDealershipContext _dbContext;
        private readonly IMapper _mapper;
        public UsersRepository(CarDealershipContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public virtual User GetById(int id)
        {
            return _mapper.Map<User>(_dbContext.Set<AppUser>().Find(id));
        }
        public virtual IQueryable<User> List()
        {
            return _dbContext.Set<AppUser>().Select(u => _mapper.Map<User>(u)).AsQueryable();
        }
        public virtual IQueryable<User> List(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            return _dbContext.Set<AppUser>().Select(u => _mapper.Map<User>(u))
                   .Where(predicate).AsQueryable();
        }
        public void Insert(User entity)
        {
            _dbContext.Set<AppUser>().Add(_mapper.Map<AppUser>(entity));
            _dbContext.SaveChanges();
        }
        public void Update(User entity)
        {
            _dbContext.Entry(_mapper.Map<AppUser>(entity)).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(User entity)
        {
            _dbContext.Set<AppUser>().Remove(_mapper.Map<AppUser>(entity));
            _dbContext.SaveChanges();
        }
    }
}
