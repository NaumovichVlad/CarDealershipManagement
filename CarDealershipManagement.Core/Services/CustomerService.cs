using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDto GetCustomerByUserName(string userName)
        {
            var customer = _customerRepository.List(c => (c.User == null ? string.Empty : c.User.UserName) == userName).First();
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                MiddleName = customer.MiddleName,
                Address = customer.Address,
                PassportData = customer.PassportData
            };
        }

        public void CreateCustomer(CustomerDto customer, User user)
        {
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
        }
    }
}
