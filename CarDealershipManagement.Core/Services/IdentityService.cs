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

        public Task<IdentityResult> AddNewUser(User user, string password, CustomerDto customer)
        {
            var results = _userRoleRepository.AddUserAsync(user, password);
            _customerRepository.Insert(new Customer
            {
                Surname = customer.Surname,
                Name = customer.Name,
                MiddleName = customer.MiddleName,
                Address = customer.Address,
                PassportData = customer.PassportData,
                UserId = user.Id,
                User = user,
            });
            return results;
        }
    }
}
