using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public EmployeeDto GetEmployeeByUserName(string userName)
        {
            var employee = _employeeRepository.ListWithIncludes(c => (c.User == null ? string.Empty : c.User.UserName) == userName, o => o.User, o => o.Position).First();
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                MiddleName = employee.MiddleName,
                PositionId = employee.PositionId,
                PositionName = employee.Position.PositionName
            };
        }
    }
}
