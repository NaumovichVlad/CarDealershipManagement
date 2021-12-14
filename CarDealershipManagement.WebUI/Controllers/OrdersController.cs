using AutoMapper;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.Cars;
using CarDealershipManagement.WebUI.ViewModels.Customers;
using CarDealershipManagement.WebUI.ViewModels.Employees;
using CarDealershipManagement.WebUI.ViewModels.Main;
using CarDealershipManagement.WebUI.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        private const int _pageSize = 10;
        private readonly IOrderService _orderService;
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IEmployeeService employeeService, IMapper mapper,
            ICarService carService, ICustomerService customerService)
        {
            _orderService = orderService;
            _employeeService = employeeService;
            _customerService = customerService;
            _carService = carService;
            _mapper = mapper;
        }

        [Authorize(Roles = "employee")]
        public IActionResult Index(int pageNumber = 1)
        {
            var orders = _orderService.GetNotApprovedOrders();
            var count = orders.Count;
            orders = orders.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();
            var page = new PageViewModel(count, pageNumber, _pageSize);
            return View(new OrdersViewModel()
            {
                Orders = _mapper.Map<List<OrderViewModel>>(orders),
                Page = page
            });
        }

        [Authorize(Roles = "employee")]
        public IActionResult Accept(int id)
        {
            var employee = _employeeService.GetEmployeeByUserName(User.Identity.Name);
            _orderService.ApproveOrder(id, employee.Id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "employee")]
        public ActionResult ForEmployee()
        {
            var employee = _employeeService.GetEmployeeByUserName(User.Identity.Name);
            var orders = _orderService.GetOrdersByEmployeeId(employee.Id);
            return View(new OrdersForEmployeeViewModel()
            {
                Orders = _mapper.Map<List<OrderViewModel>>(orders),
                Employee = _mapper.Map<EmployeeViewModel>(employee),
            });
        }

        [Authorize(Roles = "admin")]
        public IActionResult AdminIndex(string sortOrder, string searchString, string currentFilter, int pageNumber = 1)
        {
            ViewData["OrderDateParam"] = sortOrder == OrderSortState.OrderDateAsc.ToString() ? OrderSortState.OrderDateDesc.ToString() : OrderSortState.OrderDateAsc.ToString();
            ViewData["CustomerSurnameParam"] = sortOrder == OrderSortState.CustomerSurnameAsc.ToString() ? OrderSortState.CustomerSurnameDesc.ToString() : OrderSortState.CustomerSurnameAsc.ToString();
            ViewData["CarRegNumberParam"] = sortOrder == OrderSortState.CarRegNumberAsc.ToString() ? OrderSortState.CarRegNumberDesc.ToString() : OrderSortState.CarRegNumberAsc.ToString();
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;
            _ = Enum.TryParse(sortOrder, out OrderSortState sortState);

            var orders = _orderService.GetOrders();

            if (!string.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.CarRegistrationNumber.Contains(searchString)
                                       || o.EmployeeName.Contains(searchString) || o.EmployeeSurname.Contains(searchString)
                                       || o.CustomerName.Contains(searchString) || o.CustomerSurname.Contains(searchString)).ToList();
            }
            orders = sortState switch
            {
                OrderSortState.OrderDateAsc => orders.OrderBy(e => e.OrderDate).ToList(),
                OrderSortState.OrderDateDesc => orders.OrderByDescending(e => e.OrderDate).ToList(),
                OrderSortState.CustomerSurnameAsc => orders.OrderBy(e => e.CustomerSurname).ToList(),
                OrderSortState.CustomerSurnameDesc => orders.OrderByDescending(e => e.CustomerSurname).ToList(),
                OrderSortState.CarRegNumberAsc => orders.OrderBy(e => e.CarRegistrationNumber).ToList(),
                OrderSortState.CarRegNumberDesc => orders.OrderByDescending(e => e.CarRegistrationNumber).ToList(),
                _ => orders.ToList(),

            };

            var count = orders.Count;
            orders = orders.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();
            var page = new PageViewModel(count, pageNumber, _pageSize);
            return View(new OrdersViewModel()
            {
                Orders = _mapper.Map<List<OrderViewModel>>(orders),
                Page = page
            });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateOrderViewModel()
            {
                Order = new OrderViewModel()
                {
                    OrderDate = DateTime.Now,
                    SaleDate = DateTime.Now,
                    OrderCompleteMark = false
                },
                Cars = _mapper.Map<List<CarViewModel>>(_carService.GetCars()),
                Customers = _mapper.Map<List<CustomerViewModel>>(_customerService.GetCustomers()),
                Employees = _mapper.Map<List<EmployeeViewModel>>(_employeeService.GetEmployees()),
                SelectedCarIds = new List<int>(),
                SelectedEmployeeIds = new List<int>(),
                SelectedCustomerIds = new List<int>()
            });
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(CreateOrderViewModel model)
        {
            model.Order.CarId = model.SelectedCarIds.First();
            model.Order.CustomerId = model.SelectedCustomerIds.First();
            model.Order.EmployeeId = model.SelectedEmployeeIds.First();
            _orderService.CreateNewOrder(_mapper.Map<OrderDto>(model.Order));
            return RedirectToAction("AdminIndex");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _mapper.Map<OrderViewModel>(_orderService.GetOrderById(id));
            return View(new CreateOrderViewModel()
            {
                Order = order,
                Cars = _mapper.Map<List<CarViewModel>>(_carService.GetCars()),
                Customers = _mapper.Map<List<CustomerViewModel>>(_customerService.GetCustomers()),
                Employees = _mapper.Map<List<EmployeeViewModel>>(_employeeService.GetEmployees()),
                SelectedCarIds = new List<int>() { order.CarId },
                SelectedEmployeeIds = new List<int>() { (int)order.EmployeeId },
                SelectedCustomerIds = new List<int>() { order.CustomerId }
            });
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(CreateOrderViewModel model)
        {
            model.Order.CarId = model.SelectedCarIds.First();
            model.Order.CustomerId = model.SelectedCustomerIds.First();
            model.Order.EmployeeId = model.SelectedEmployeeIds.First();
            _orderService.EditOrder(_mapper.Map<OrderDto>(model.Order));
            return RedirectToAction("AdminIndex");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _orderService.DeleteOrderById(id);
            return RedirectToAction("AdminIndex");
        }

    }

    public enum OrderSortState
    {
        OrderDateDesc,
        OrderDateAsc,
        CustomerSurnameDesc,
        CustomerSurnameAsc,
        CarRegNumberAsc,
        CarRegNumberDesc,
    }
}
