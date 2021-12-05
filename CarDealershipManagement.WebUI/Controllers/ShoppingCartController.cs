using AutoMapper;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize(Roles = "customer")]
    public class ShoppingCartController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        public ShoppingCartController(IOrderService orderService, ICustomerService customerService, 
            IMapper mapper, ICarService carService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _carService = carService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var customer = _customerService.GetCustomerByUserName(User.Identity.Name);
            var orders = _orderService.GetOrdersByCustomerId(customer.Id);
            var cars = orders.Select(o => _carService.GetCarById(o.CarId));
            return View(new ShoppingCartViewModel()
            {
                Orders = _mapper.Map<List<OrderViewModel>>(orders),
                Customer = _mapper.Map<CustomerViewModel>(customer),
                Cars = _mapper.Map<List<CarViewModel>>(cars),
            });
        }
    }
}
