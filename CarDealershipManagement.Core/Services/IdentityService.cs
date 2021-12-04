using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRepository<Customer> _customerRepository;
        public IdentityService(IUserRoleRepository userRoleRepository, IRepository<Customer> customerRepository)
        {
            _userRoleRepository = userRoleRepository;
            _customerRepository = customerRepository;
        }

        public Task<IdentityResult> AddNewUserRole(User user, string role)
        {
            return _userRoleRepository.AddUserRoleAsync(user, role);
        }

        public Task<IdentityResult> AddNewUser(User user, string password)
        {
             return _userRoleRepository.AddUserAsync(user, password);
        }

        public User GetUserByUserName(string userName)
        {
            return _userRoleRepository.UserList().Find(u => u.UserName == userName);
        }
    }
}
