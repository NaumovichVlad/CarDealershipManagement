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
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Position> _poitionRepository;
        public EmployeeService(IRepository<Employee> employeeRepository, IRepository<Position> poitionRepository)
        {
            _employeeRepository = employeeRepository;
            _poitionRepository = poitionRepository;
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

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            var position = _poitionRepository.GetById(employee.PositionId);
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                MiddleName = employee.MiddleName,
                PositionId = employee.PositionId,
                PositionName = position.PositionName,
            };
        }

        public List<EmployeeDto> GetEmployees()
        {
            var employees = _employeeRepository.List();
            var positions = _poitionRepository.List().ToList();
            var employeesDto = employees.Select(employee => new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                MiddleName = employee.MiddleName,
                PositionId = employee.PositionId,
                PositionName = positions.First(p => p.Id == employee.PositionId).PositionName
            }).ToList();
            return employeesDto;
        }

        public void CreateEmployee(EmployeeDto employee)
        {
            _employeeRepository.Insert(new Employee()
            {
                Surname = employee.Surname,
                Name = employee.Name,
                MiddleName = employee.MiddleName,
                PositionId = employee.PositionId,
            });
        }

        public void DeleteEmployeeById(int id)
        {
            _employeeRepository.Delete(_employeeRepository.GetById(id));
        }

        public void EditEmployee(EmployeeDto employee)
        {
            _employeeRepository.Update(new Employee()
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.Name,
                MiddleName = employee.MiddleName,
                PositionId = employee.PositionId
            });
        }
    }
}
