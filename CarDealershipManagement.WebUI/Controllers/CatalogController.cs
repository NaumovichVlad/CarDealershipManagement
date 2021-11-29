using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ICarBasisService _carBasisService;
        private readonly ICarSpecificationService _carSpecificationService;
        private readonly ICarService _carService;

        public int CarId { get; set; }

        public CatalogController(ICarBasisService carBasisService, ICarService carService,
            ICarSpecificationService carSpecificationService)
        {
            _carBasisService = carBasisService;
            _carSpecificationService = carSpecificationService;
            _carService = carService;
        }

        [AllowAnonymous]
        public IActionResult Index(int carId = 0)
        {
            carId = carId == 0 ? CarId : carId;
            var specification = _carSpecificationService.GetCarSpecificationsByCarId(carId);
            var car = _carBasisService.GetCarById(carId);
            return View(new CatalogViewModel { 
                Car = car, 
                Specifications = specification, 
                IsInStock = _carService.CheckIsFree(carId)
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult RouteToHome()
        {
            return RedirectToAction("Index", "Home", new {});
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Buy(int id)
        {
            if (User.IsInRole("customer"))
                return RedirectToAction("Index", "Purchase", new {CarId = id});
            else
                return RedirectToAction("Login", "Account");
        }
    }
}
