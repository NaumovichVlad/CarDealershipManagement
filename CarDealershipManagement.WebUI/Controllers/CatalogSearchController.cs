using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class CatalogSearchController : Controller
    {
        private readonly ICarsService _carService;
        public CatalogSearchController(ICarsService carService)
        {
            _carService = carService;
        }
        public IActionResult Search(string sortOrder, string searchString)
        {
            ViewData["BrandSortParm"] = string.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewData["ManufacturerSortParm"] = string.IsNullOrEmpty(sortOrder) ? "manufacturer_desc" : "";
            ViewData["PriceSortParm"] = string.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var cars = _carService.GetCars().Select(c => new CarHomeViewModel()
            {
                Id = c.Id,
                BrandName = c.BrandName,
                Picture = c.Picture,
                ManufacturerName = c.ManufacturerName,
                Price = c.Price,
            });
            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(c => c.BrandName.Contains(searchString)
                                       || c.ManufacturerName.Contains(searchString));
            }
            cars = sortOrder switch
            {
                "brand_desc" => cars.OrderByDescending(c => c.BrandName),
                "price_desc" => cars.OrderByDescending(c => c.Price),
                "manufacturer_desc" => cars.OrderByDescending(c => c.ManufacturerName),
                _ => cars.OrderBy(c => c.BrandName),
            };
            return View(new SearchViewModel { Cars = cars.ToList() });
        }

        [HttpGet]
        public IActionResult RouteToDetailsPage(int id)
        {
            return RedirectToAction("Index", "Catalog", new { CarId = id });
        }
    }
}
