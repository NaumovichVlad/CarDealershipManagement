using AutoMapper;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize(Roles = "customer")]
    public class PurchaseController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarEquipmentService _carEquipmentService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public int CarId { get; set; }

        public PurchaseController(ICarService carService, ICarEquipmentService carEquipmentService, ICustomerService customerService,
            IOrderService orderService, IMapper mapper)
        {
            _carService = carService;
            _carEquipmentService = carEquipmentService;
            _customerService = customerService;
            _orderService = orderService;
            _mapper = mapper;
        }


        public IActionResult Index(int carId = 0)
        {
            carId = carId == 0 ? CarId : carId;
            var car = _mapper.Map<CarViewModel>(_carService.GetFreeCarByCarBasisId(carId));
            var carEquipments = _mapper.Map<List<CarEquipmentViewModel>>(_carEquipmentService.GetCarEquipmentsByCarId(car.Id) ?? new List<CarEquipmentDto>());

            return View(new PurchaseViewModel()
            {
                Car = car,
                CarEquipments = carEquipments,
            });
        }

        public ActionResult AddOrder(int id = 0)
        {
            var car = _carService.GetCarById(id);
            var customer = _customerService.GetCustomerByUserName(User.Identity.Name);
            _orderService.CreateNewOrder(_mapper.Map<CarDto>(car), customer);
            return RedirectToAction("Index", "ShoppingCart", new {});
        }
    }
}
