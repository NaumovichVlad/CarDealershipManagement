using CarDealershipManagement.Core.ModelsDto;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployeeByUserName(string userName);
    }
}
