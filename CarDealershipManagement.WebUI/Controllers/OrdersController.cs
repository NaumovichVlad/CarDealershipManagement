using AutoMapper;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels.Employees;
using CarDealershipManagement.WebUI.ViewModels.Main;
using CarDealershipManagement.WebUI.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize(Roles = "employee")]
    public class OrdersController : Controller
    {
        private const int _pageSize = 10;
        private readonly IOrderService _orderService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IEmployeeService employeeService, IMapper mapper)
        {
            _orderService = orderService;
            _employeeService = employeeService;
            _mapper = mapper;
        }
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

        public IActionResult Accept(int id)
        {
            var employee = _employeeService.GetEmployeeByUserName(User.Identity.Name);
            _orderService.ApproveOrder(id, employee.Id);
            return RedirectToAction("Index");
        }

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
    }
}
