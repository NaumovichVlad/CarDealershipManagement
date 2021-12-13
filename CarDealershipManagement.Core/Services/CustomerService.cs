using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    /// <summary>
    /// Сервис для раьоты с репозиторием
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDto GetCustomerById(int id)
        {
            var customer = _customerRepository.GetById(id);
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

        public List<CustomerDto> GetCustomers() => _customerRepository.List().Select(c => new CustomerDto
        {
            Id = c.Id,
            Surname = c.Surname,
            Name = c.Name,
            MiddleName = c.MiddleName,
            PassportData = c.PassportData,
            Address = c.Address
        }).ToList();

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

        public void CreateCustomer(CustomerDto customer)
        {
            _customerRepository.Insert(new Customer
            {
                Surname = customer.Surname,
                Name = customer.Name,
                MiddleName = customer.MiddleName,
                Address = customer.Address,
                PassportData = customer.PassportData,
            });
        }

        public void EditCustomer(CustomerDto customer)
        {
            _customerRepository.Update(new Customer()
            {
                Id = customer.Id,
                Surname = customer.Surname,
                Name = customer.Name,
                MiddleName = customer.MiddleName,
                Address = customer.Address,
                PassportData = customer.PassportData,
            });
        }

        public void DeleteCustomerById(int id)
        {
            _customerRepository.Delete(_customerRepository.GetById(id));
        }
    }
}
