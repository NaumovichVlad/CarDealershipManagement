using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.Extensions;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarEquipmentService _carEquipmentService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        public int CarId { get; set; }

        public PurchaseController(ICarService carService, ICarEquipmentService carEquipmentService, ICustomerService customerService,
            IOrderService orderService)
        {
            _carService = carService;
            _carEquipmentService = carEquipmentService;
            _customerService = customerService;
            _orderService = orderService;
        }


        public IActionResult Index(int carId = 0)
        {
            carId = carId == 0 ? CarId : carId;
            var car = _carService.GetFreeCarByCarBasisId(carId);
            HttpContext.Session.Set("car", car);
            var carEquipments = _carEquipmentService.GetCarEquipmentsByCarId(car.Id) ?? new List<CarEquipmentDto>();

            return View(new PurchaseViewModel()
            {
                Car = car,
                CarEquipments = carEquipments,
            });
        }

        public ActionResult AddOrder()
        {
            var car = HttpContext.Session.Get<CarDto>("car");
            var customer = _customerService.GetCustomerByUserName(User.Identity.Name);
            _orderService.CreateNewOrder(car, customer);
            return RedirectToAction("Index");
        }
    }
}
