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
            var customer = _customerRepository.ListWithIncludes(c => c.User.UserName == userName, c => c.User).First();
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
    }
}
