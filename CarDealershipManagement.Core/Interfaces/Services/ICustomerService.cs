using CarDealershipManagement.Core.ModelsDto;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        CustomerDto GetCustomerByUserName(string userName);
    }
}
