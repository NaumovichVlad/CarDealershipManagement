﻿using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICarsService _carsService;
        public HomeController(ICarsService carsService)
        {
            _carsService = carsService;
        }
        [AllowAnonymous]
        public IActionResult Index(int pageNumber = 1)
        {
            int pageSize = 6;
            var skip = (pageNumber - 1) * pageSize;
            
            var cars = _carsService.GetCarsRange(skip, skip + pageSize).Select(c => new CarHomeViewModel()
            {
                Id = c.Id,
                BrandName = c.BrandName,
                Picture = c.Picture,
                ManufacturerName = c.ManufacturerName,
                Price = c.Price,
            }).ToList();
            PageViewModel pageViewModel = new(_carsService.Count(), pageNumber, pageSize);
            var model = new CarsHomeViewModel { Page = pageViewModel, Cars = cars };
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
