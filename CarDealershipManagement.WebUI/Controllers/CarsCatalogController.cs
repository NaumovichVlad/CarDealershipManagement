using CarDealershipManagement.Core.Services;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class CarsCatalogController : Controller
    {
        private ICarsService _carsService;
        public CarsCatalogController(ICarsService carsService)
        {
            _carsService = carsService;
        }
        public IActionResult Index()
        {
            var cars = _carsService.GetCars().Select(c => new CarForCatalogViewModel()
            {
                Id = c.Id,
                BrandName = c.BrandName,
                ManufacturerName = c.ManufacturerName,
                Price = c.Price,
            });
            return View(new CarsForCatalogViewModel() { Cars = cars.ToList() });
        }
    }
}
