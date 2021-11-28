using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ICarsService _carService;
        private readonly ICarSpecificationService _carSpecificationService;
        private readonly ICarEquipmentService _carEquipmentService;

        public int CarId { get; set; }

        public CatalogController(ICarsService carService, ICarEquipmentService carEquipmentService, 
            ICarSpecificationService carSpecificationService)
        {
            _carService = carService;
            _carEquipmentService = carEquipmentService;
            _carSpecificationService = carSpecificationService;
        }

        [AllowAnonymous]
        public IActionResult Index(int carId = 0)
        {
            carId = carId == 0 ? CarId : carId;
            var equipment = _carEquipmentService.GetCarEquipmentsByCarId(carId);
            var specification = _carSpecificationService.GetCarSpecificationsByCarId(carId);
            var car = _carService.GetCarById(carId);
            return View(new CatalogViewModel { Car = car, Equipments = equipment, Specifications = specification });
        }
    }
}
