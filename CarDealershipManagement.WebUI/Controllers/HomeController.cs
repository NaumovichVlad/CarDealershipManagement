using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels.CarsBasis;
using CarDealershipManagement.WebUI.ViewModels.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICarBasisService _carsService;
        public HomeController(ICarBasisService carsService)
        {
            _carsService = carsService;
        }
        [AllowAnonymous]
        public IActionResult Index(int pageNumber = 1)
        {
            int pageSize = 6;
            var skip = (pageNumber - 1) * pageSize;
            
            var cars = _carsService.GetCarsRange(skip, skip + pageSize).Select(c => new CarBasisViewModel()
            {
                Id = c.Id,
                BrandName = c.BrandName,
                Picture = c.Picture,
                ManufacturerName = c.ManufacturerName,
                Price = c.Price,
            }).ToList();
            PageViewModel pageViewModel = new PageViewModel(_carsService.Count(), pageNumber, pageSize);
            var model = new CarsBasisViewModel { Page = pageViewModel, Cars = cars };
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult RouteToDetailsPage(int id)
        {
            return RedirectToAction("Index", "Catalog", new {CarId = id});
        }
    }
}
