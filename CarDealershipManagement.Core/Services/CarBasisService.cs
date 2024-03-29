﻿using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    /// <summary>
    /// Сервис для раьоты с репозиторием
    /// </summary>
    public class CarBasisService : ICarBasisService
    {
        private readonly IRepository<CarBasis> _carsBasisRepository;
        private readonly IRepository<Brand> _brandRepository;
        public CarBasisService(IRepository<CarBasis> carsBasisRepository,
            IRepository<Brand> brandRepository)
        {
            _carsBasisRepository = carsBasisRepository;
            _brandRepository = brandRepository;
        }

        public List<CarBasisDto> GetCars()
        {
            var cars = _carsBasisRepository.List().ToList();
            foreach (var car in cars)
            {
                var brand = _brandRepository.GetByIdWithIncludes(car.BrandId, b => b.Manufacturer);
                car.Brand = brand;
            }
            return cars.Select(c => new CarBasisDto()
            {
                Id = c.Id,
                BrandName = c.Brand.BrandName,
                ManufacturerName = c.Brand.Manufacturer.ManufacturerName,
                Picture = c.Picture,
                Color = c.Color,
                Price = Math.Round(c.Price, 2),
            }).ToList();
        }

        public List<CarBasisDto> GetCarsRange(int start, int end)
        {
            return _carsBasisRepository.GetRangeWithIncludes(start, end, c => c.Brand.Manufacturer)
                .Select(c => new CarBasisDto()
                {
                    Id = c.Id,
                    BrandName = c.Brand.BrandName,
                    ManufacturerName = c.Brand.Manufacturer.ManufacturerName,
                    Picture = c.Picture,
                    Color = c.Color,
                    Price = Math.Round(c.Price, 2),
                }).ToList();
        }

        public CarBasisDto GetCarById(int id)
        {
            var car = _carsBasisRepository.GetByIdWithIncludes(id, c => c.Brand.Manufacturer);
            return new CarBasisDto()
            {
                Id = car.Id,
                BrandName = car.Brand.BrandName,
                ManufacturerName = car.Brand.Manufacturer.ManufacturerName,
                Picture = car.Picture,
                Color = car.Color,
                Price = Math.Round(car.Price, 2),
            };
        }

        public int Count()
        {
            return _carsBasisRepository.GetCount();
        }
    }
}
