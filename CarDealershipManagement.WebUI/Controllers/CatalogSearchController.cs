using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels.CarsBasis;
using CarDealershipManagement.WebUI.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class CatalogSearchController : Controller
    {
        private readonly ICarBasisService _carBasisService;
        private const int pageSize = 8;
        public CatalogSearchController(ICarBasisService carService)
        {
            _carBasisService = carService;
        }
        public IActionResult Search(string sortOrder, string searchString, string currentFilter, int pageNumber = 1)
        {
            ViewData["BrandSortParam"] = sortOrder == CarSortState.BrandNameAsc.ToString() ? CarSortState.BrandNameDesc.ToString() : CarSortState.BrandNameAsc.ToString();
            ViewData["ManufacturerNameSortParam"] = sortOrder == CarSortState.ManufacturerNameAsc.ToString() ? CarSortState.ManufacturerNameDesc.ToString() : CarSortState.ManufacturerNameAsc.ToString();
            ViewData["PriceSortParam"] = sortOrder == CarSortState.PriceAsc.ToString() ? CarSortState.PriceDesc.ToString() : CarSortState.PriceAsc.ToString();
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
                pageNumber = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;

            _ = Enum.TryParse(sortOrder, out CarSortState sortState);
            var cars = _carBasisService.GetCars().Select(c => new CarBasisViewModel()
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
            cars = sortState switch
            {
                CarSortState.BrandNameDesc => cars.OrderByDescending(c => c.BrandName),
                CarSortState.BrandNameAsc => cars.OrderBy(c => c.BrandName),
                CarSortState.ManufacturerNameDesc => cars.OrderByDescending(c => c.ManufacturerName),
                CarSortState.ManufacturerNameAsc => cars.OrderBy(c => c.ManufacturerName),
                CarSortState.PriceDesc => cars.OrderByDescending(c => c.Price),
                CarSortState.PriceAsc => cars.OrderBy(c => c.Price),
                _ => cars,
            };
            var count = cars.Count();
            cars = cars.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var _page = new PageViewModel(count, pageNumber, pageSize);
            return View(new SearchViewModel { Cars = cars.ToList(), Page = _page });
        }

        [HttpGet]
        public IActionResult RouteToDetailsPage(int id)
        {
            return RedirectToAction("Index", "Catalog", new { CarId = id });
        }
    }

    public enum CarSortState
    {
        No,
        BrandNameAsc,
        BrandNameDesc,
        ManufacturerNameAsc,
        ManufacturerNameDesc,
        PriceAsc,
        PriceDesc
    }
}
