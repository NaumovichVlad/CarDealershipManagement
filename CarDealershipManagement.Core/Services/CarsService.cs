using CarDealershipManagement.Core.BusinessModels;
using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    public class CarsService : ICarsService
    {
        private readonly IRepository<Car> _carsRepository;
        public CarsService(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public List<CarBusiness> GetCars()
        {
            return _carsRepository.ListWithIncludes(c => c.Brand, c => c.Manufacturer)
                .Select(c => new CarBusiness()
            {
                Id = c.Id,
                RegistrationNumber = c.RegistrationNumber,
                BrandName = c.Brand.BrandName,
                ManufacturerName = c.Manufacturer.ManufacturerName,
                Picture = c.Picture,
                Color = c.Color,
                BodyTypeNumber = c.BodyTypeNumber,
                EngineNumber = c.EngineNumber,
                Price = Math.Round(c.Price, 2),
            }).ToList();
        }

        public List<CarBusiness> GetCarsRange(int start, int end)
        {
            return _carsRepository.GetRangeWithIncludes(start, end, c => c.Brand, c => c.Manufacturer)
                .Select(c => new CarBusiness()
                {
                    Id = c.Id,
                    RegistrationNumber = c.RegistrationNumber,
                    BrandName = c.Brand.BrandName,
                    ManufacturerName = c.Manufacturer.ManufacturerName,
                    Picture = c.Picture,
                    Color = c.Color,
                    BodyTypeNumber = c.BodyTypeNumber,
                    EngineNumber = c.EngineNumber,
                    Price = Math.Round(c.Price, 2),
                }).ToList();
        }

        public CarBusiness GetCarById(int id)
        {
            var car = _carsRepository.GetByIdWithIncludes(id, c => c.Brand, c => c.Manufacturer);
            return new CarBusiness()
            {
                Id = car.Id,
                RegistrationNumber = car.RegistrationNumber,
                BrandName = car.Brand.BrandName,
                ManufacturerName = car.Manufacturer.ManufacturerName,
                Picture = car.Picture,
                Color = car.Color,
                BodyTypeNumber = car.BodyTypeNumber,
                EngineNumber = car.EngineNumber,
                Price = Math.Round(car.Price, 2),
            };
        }

        public int Count()
        {
            return _carsRepository.GetCount();
        }
    }
}
