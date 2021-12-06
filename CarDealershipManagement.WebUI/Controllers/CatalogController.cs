using AutoMapper;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels.CarsBasis;
using CarDealershipManagement.WebUI.ViewModels.CarsSpecifications;
using CarDealershipManagement.WebUI.ViewModels.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ICarBasisService _carBasisService;
        private readonly ICarSpecificationService _carSpecificationService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public int CarId { get; set; }

        public CatalogController(ICarBasisService carBasisService, ICarService carService,
            ICarSpecificationService carSpecificationService, IMapper mapper)
        {
            _carBasisService = carBasisService;
            _carSpecificationService = carSpecificationService;
            _carService = carService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public IActionResult Index(int carId = 0)
        {
            carId = carId == 0 ? CarId : carId;
            var specifications = _mapper.Map<List<CarSpecificationViewModel>>(_carSpecificationService.GetCarSpecificationsByCarId(carId));
            var car = _mapper.Map<CarBasisViewModel>(_carBasisService.GetCarById(carId));
            return View(new CatalogViewModel { 
                Car = car, 
                Specifications = specifications, 
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
