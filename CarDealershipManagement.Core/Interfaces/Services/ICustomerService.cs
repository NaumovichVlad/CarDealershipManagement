using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для взаимодействия с сервисом
    /// </summary>
    public interface ICustomerService
    {
        CustomerDto GetCustomerById(int id);
        CustomerDto GetCustomerByUserName(string userName);
        void CreateCustomer(CustomerDto customer, User user);
        void CreateCustomer(CustomerDto customer);
        void EditCustomer(CustomerDto customer);
        List<CustomerDto> GetCustomers();
        void DeleteCustomerById(int id);
    }
}
