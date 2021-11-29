using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarEquipmentService _carEquipmentService;
        public int CarId { get; set; }

        public PurchaseController(ICarService carService, ICarEquipmentService carEquipmentService)
        {
            _carService = carService;
            _carEquipmentService = carEquipmentService;
        }

        public IActionResult Index(int carId = 0)
        {
            carId = carId == 0 ? CarId : carId;
            var car = _carService.GetFreeCarByCarBasisId(carId);
            var carEquipments = _carEquipmentService.GetCarEquipmentsByCarId(car.Id) ?? new List<CarEquipmentDto>();

            return View(new PurchaseViewModel()
            {
                Car = car,
                CarEquipments = carEquipments,
            });
        }
    }
}
