using CarDealershipManagement.Core.Services;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarsService _carsService;
        public HomeController(ICarsService carsService)
        {
            _carsService = carsService;
        }
        public IActionResult Index()
        {
            
            var cars = _carsService.GetCars().Select(c => new CarForCatalogViewModel()
            {
                Id = c.Id,
                BrandName = c.BrandName,
                Picture = c.Picture,
                ManufacturerName = c.ManufacturerName,
                Price = c.Price,
            });
            return View(new CarsForCatalogViewModel() { Cars = cars.ToList() });
        }
    }
}
