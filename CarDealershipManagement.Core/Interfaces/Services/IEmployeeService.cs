using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для взаимодействия с сервисом
    /// </summary>
    public interface IEmployeeService
    {

        EmployeeDto GetEmployeeByUserName(string userName);
        List<EmployeeDto> GetEmployees();
        void CreateEmployee(EmployeeDto employee);
        void DeleteEmployeeById(int id);
        void EditEmployee(EmployeeDto employee);
        EmployeeDto GetEmployeeById(int id);
    }
}
