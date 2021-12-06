using AutoMapper;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.Employees;
using CarDealershipManagement.WebUI.ViewModels.Main;
using CarDealershipManagement.WebUI.ViewModels.Positions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        private const int pageSize = 10;

        public EmployeesController(IEmployeeService employeeService, 
            IPositionService positionService, IMapper mapper)
        {
            _employeeService = employeeService;
            _positionService = positionService;
            _mapper = mapper;
        }

        public IActionResult Index(string sortOrder, string searchString, string currentFilter, int pageNumber = 1)
        {
            ViewData["SurnameSortParam"] = sortOrder == EmployeeSortState.SurnameAsc.ToString() ? EmployeeSortState.SurnameDesc.ToString() : EmployeeSortState.SurnameAsc.ToString();
            ViewData["NameSortParam"] = sortOrder == EmployeeSortState.NameAsc.ToString() ? EmployeeSortState.NameDesc.ToString() : EmployeeSortState.NameAsc.ToString();
            ViewData["MiddleNameSortParam"] = sortOrder == EmployeeSortState.MiddleNameAsc.ToString() ? EmployeeSortState.MiddleNameDesc.ToString() : EmployeeSortState.MiddleNameAsc.ToString();
            ViewData["PositionSortParam"] = sortOrder == EmployeeSortState.PositionAsc.ToString() ? EmployeeSortState.PositionDesc.ToString() : EmployeeSortState.PositionAsc.ToString();
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;

            _ = Enum.TryParse(sortOrder, out EmployeeSortState sortState);
            var employees = _employeeService.GetEmployees();
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.Surname.Contains(searchString)
                                       || e.Name.Contains(searchString) || e.MiddleName.Contains(searchString)
                                       || e.PositionName.Contains(searchString)).ToList();
            }
            employees = sortState switch
            {
                EmployeeSortState.SurnameAsc => employees.OrderBy(e => e.Surname).ToList(),
                EmployeeSortState.SurnameDesc => employees.OrderByDescending(e => e.Surname).ToList(),
                EmployeeSortState.NameAsc => employees.OrderBy(e => e.Name).ToList(),
                EmployeeSortState.NameDesc => employees.OrderByDescending(e => e.Name).ToList(),
                EmployeeSortState.MiddleNameAsc => employees.OrderBy(e => e.MiddleName).ToList(),
                EmployeeSortState.MiddleNameDesc => employees.OrderByDescending(e => e.MiddleName).ToList(),
                EmployeeSortState.PositionAsc => employees.OrderBy(e => e.PositionName).ToList(),
                EmployeeSortState.PositionDesc => employees.OrderByDescending(e => e.PositionName).ToList(),
                _ => employees.ToList(),

            };
            var count = employees.Count;
            employees = employees.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var page = new PageViewModel(count, pageNumber, pageSize);
            return View(new EmployeesViewModel { Employees = _mapper.Map<List<EmployeeViewModel>>(employees), Page = page });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateEmployeeViewModel()
            {
                Employee = new EmployeeViewModel(),
                Positions = _mapper.Map<List<PositionViewModel>>(_positionService.GetPositions()),
                SelectedPositionIds = new List<int>()
            }) ;
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            model.Employee.PositionId = model.SelectedPositionIds.First();
            _employeeService.CreateEmployee(_mapper.Map<EmployeeDto>(model.Employee));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _mapper.Map<EmployeeViewModel>(_employeeService.GetEmployeeById(id));
            return View(new CreateEmployeeViewModel()
            {
                Employee = employee,
                Positions = _mapper.Map<List<PositionViewModel>>(_positionService.GetPositions()),
                SelectedPositionIds = new List<int>() { employee.PositionId }
            });
        }

        [HttpPost]
        public IActionResult Edit(CreateEmployeeViewModel model)
        {
            model.Employee.PositionId = model.SelectedPositionIds.First();
            _employeeService.EditEmployee(_mapper.Map<EmployeeDto>(model.Employee));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployeeById(id);
            return RedirectToAction("Index");
        }

    }

    public enum EmployeeSortState
    {
        SurnameAsc,
        SurnameDesc,
        NameAsc,
        NameDesc,
        MiddleNameAsc,
        MiddleNameDesc,
        PositionAsc,
        PositionDesc,
    }
}
