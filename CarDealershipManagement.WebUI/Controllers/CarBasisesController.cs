/*using AutoMapper;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels.Cars;
using CarDealershipManagement.WebUI.ViewModels.CarsBasis;
using CarDealershipManagement.WebUI.ViewModels.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CarBasisesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICarBasisService _carBasisService;
        private const int _pageSize = 10;
        public CarBasisesController(IMapper mapper, ICarBasisService carBasisService)
        {
            _mapper = mapper;
            _carBasisService = carBasisService;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index(string sortOrder, string searchString, string currentFilter, int pageNumber = 1)
        {
            ViewData["BrandSortParam"] = sortOrder == CarSortState.BrandNameAsc.ToString() ? CarSortState.BrandNameDesc.ToString() : CarSortState.BrandNameAsc.ToString();
            ViewData["ManufacturerNameSortParam"] = sortOrder == CarSortState.ManufacturerNameAsc.ToString() ? CarSortState.ManufacturerNameDesc.ToString() : CarSortState.ManufacturerNameAsc.ToString();
            ViewData["PriceSortParam"] = sortOrder == CarSortState.PriceAsc.ToString() ? CarSortState.PriceDesc.ToString() : CarSortState.PriceAsc.ToString();
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;
            _ = Enum.TryParse(sortOrder, out OrderSortState sortState);

            var cars = _carBasisService.GetCars();

            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(c => c.BrandName.Contains(searchString) || c.ManufacturerName.Contains(searchString) 
            }
            cars = sortState switch
            {
                CarSortState.BrandNameDesc => cars.OrderByDescending(c => c.BrandName),
                CarSortState.BrandNameAsc => cars.OrderBy(c => c.BrandName),
                CarSortState.ManufacturerNameDesc => cars.OrderByDescending(c => c.ManufacturerName),
                CarSortState.ManufacturerNameAsc => cars.OrderBy(c => c.ManufacturerName),
                CarSortState.PriceDesc => cars.OrderByDescending(c => c.Price),
                CarSortState.PriceAsc => cars.OrderBy(c => c.Price),
                _ => cars,
            };

            var count = cars.Count();
            cars = cars.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();
            var _page = new PageViewModel(count, pageNumber, _pageSize);
            return View(new SearchViewModel { Cars = _mapper.Map<List<CarBasisViewModel>>(cars), Page = _page });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateCarBasisViewModel()
            {
                Order = new CarViewModel()
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
        public IActionResult Create(CreateCarBasisViewModel model)
        {
            model.Car.CarId = model.SelectedCarIds.First();
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
            _orderService.EditOrder(_mapper.Map<OrderDto>(model));
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
}
*/