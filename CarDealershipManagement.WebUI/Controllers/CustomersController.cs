using AutoMapper;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels.Customers;
using CarDealershipManagement.WebUI.ViewModels.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private const int pageSize = 10;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public IActionResult Index(string sortOrder, string searchString, string currentFilter, int pageNumber = 1)
        {
            ViewData["SurnameSortParam"] = sortOrder == CustomerSortState.SurnameAsc.ToString() ? CustomerSortState.SurnameDesc.ToString() : CustomerSortState.SurnameAsc.ToString();
            ViewData["NameSortParam"] = sortOrder == CustomerSortState.NameAsc.ToString() ? CustomerSortState.NameDesc.ToString() : CustomerSortState.NameAsc.ToString();
            ViewData["MiddleNameSortParam"] = sortOrder == CustomerSortState.MiddleNameAsc.ToString() ? CustomerSortState.MiddleNameDesc.ToString() : CustomerSortState.MiddleNameAsc.ToString();
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;

            _ = Enum.TryParse(sortOrder, out CustomerSortState sortState);
            var customers = _customerService.GetCustomers();
            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(e => e.Surname.Contains(searchString)
                                       || e.Name.Contains(searchString) || e.MiddleName.Contains(searchString)
                                       || e.PassportData.Contains(searchString)).ToList();
            }
            customers = sortState switch
            {
                CustomerSortState.SurnameAsc => customers.OrderBy(e => e.Surname).ToList(),
                CustomerSortState.SurnameDesc => customers.OrderByDescending(e => e.Surname).ToList(),
                CustomerSortState.NameAsc => customers.OrderBy(e => e.Name).ToList(),
                CustomerSortState.NameDesc => customers.OrderByDescending(e => e.Name).ToList(),
                CustomerSortState.MiddleNameAsc => customers.OrderBy(e => e.MiddleName).ToList(),
                CustomerSortState.MiddleNameDesc => customers.OrderByDescending(e => e.MiddleName).ToList(),
                _ => customers.ToList(),

            };
            var count = customers.Count;
            customers = customers.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var page = new PageViewModel(count, pageNumber, pageSize);
            return View(new CustomersViewModel { Customers = _mapper.Map<List<CustomerViewModel>>(customers), Page = page });
        }

        [HttpGet]
        public IActionResult Create() => View(new CustomerViewModel());


        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            _customerService.CreateCustomer(_mapper.Map<CustomerDto>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) =>
            View(_mapper.Map<CustomerViewModel>(_customerService.GetCustomerById(id)));



        [HttpPost]
        public IActionResult Edit(CustomerViewModel model)
        {
            _customerService.EditCustomer(_mapper.Map<CustomerDto>(model));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _customerService.DeleteCustomerById(id);
            return RedirectToAction("Index");
        }

    }

    public enum CustomerSortState
    {
        SurnameAsc,
        SurnameDesc,
        NameAsc,
        NameDesc,
        MiddleNameAsc,
        MiddleNameDesc,
    }
}
