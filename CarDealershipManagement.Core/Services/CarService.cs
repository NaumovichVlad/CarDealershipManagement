using CarDealershipManagement.Core.Interfaces.Repositories;
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
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carsRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IRepository<CarBasis> _carBasisRepository;
        public CarService(IRepository<Car> carsRepository, IRepository<Order> orderRepository,
            IRepository<Brand> brandRepository, IRepository<CarBasis> carBasisRepository)
        {
            _carsRepository = carsRepository;
            _orderRepository = orderRepository;
            _brandRepository = brandRepository;
            _carBasisRepository = carBasisRepository;
        }

        public IEnumerable<CarDto> GetCars()
        {
            return _carsRepository.ListWithIncludes(c => c.CarBasis, c => c.CarBasis.Brand, c => c.CarBasis.Brand.Manufacturer)
                .Select(c => new CarDto()
                {
                    Id = c.Id,
                    RegistrationNumber = c.RegistrationNumber,
                    BodyTypeNumber = c.BodyTypeNumber,
                    EngineNumber = c.EngineNumber,
                    BrandName = c.CarBasis.Brand.BrandName,
                    ManufacturerName = c.CarBasis.Brand.Manufacturer.ManufacturerName,
                    Picture = c.CarBasis.Picture,
                    Color = c.CarBasis.Color,
                    Price = Math.Round(c.CarBasis.Price, 2)
                });
        }
        public bool CheckIsFree(int carBasisId)
        {
            var cars = _carsRepository.List(c => c.CarBasisId == carBasisId).Select(c => c.Id);
            if (!cars.Any())
                return false;
            var orders = _orderRepository.List(o => cars.Contains(o.CarId)).Count();
            return !(cars.Count() == orders);
        }

        public List<CarDto> GetCarsByCarBasisId(int carBasisId)
        {
            return _carsRepository.ListWithIncludes(c => c.CarBasisId == carBasisId,
                c => c.CarBasis, c => c.CarBasis.Brand, c => c.CarBasis.Brand.Manufacturer)
                .Select(c => new CarDto()
                {
                    Id = c.Id,
                    RegistrationNumber = c.RegistrationNumber,
                    BodyTypeNumber = c.BodyTypeNumber,
                    EngineNumber = c.EngineNumber,
                    BrandName = c.CarBasis.Brand.BrandName,
                    ManufacturerName = c.CarBasis.Brand.Manufacturer.ManufacturerName,
                    Picture = c.CarBasis.Picture,
                    Color = c.CarBasis.Color,
                    Price = Math.Round(c.CarBasis.Price, 2)
                }).ToList();
        }

        public CarDto GetFreeCarByCarBasisId(int carBasisId)
        {
            var orders = _orderRepository.ListWithIncludes(o => o.Car.CarBasisId == carBasisId, o => o.Car).Select(o => o.Id).ToList();
            List<Car> cars;
            if (orders.Any())
                cars = _carsRepository.List(c => c.CarBasis.Id == carBasisId && !orders.Contains(c.Id)).ToList();
            else
                cars = _carsRepository.List(c => c.CarBasis.Id == carBasisId).ToList();
            if (cars.Any())
            {
                var car = cars.First();
                var carBasis = _carBasisRepository.GetById(carBasisId);
                var brand = _brandRepository.GetByIdWithIncludes(carBasis.Id, b => b.Manufacturer);
                return new CarDto()
                {
                    Id = car.Id,
                    RegistrationNumber = car.RegistrationNumber,
                    BodyTypeNumber = car.BodyTypeNumber,
                    EngineNumber = car.EngineNumber,
                    BrandName = brand.BrandName,
                    ManufacturerName = brand.Manufacturer.ManufacturerName,
                    Picture = carBasis.Picture,
                    Color = carBasis.Color,
                    Price = Math.Round(carBasis.Price, 2)
                };
            }
            else return null;

        }

        public CarDto GetCarById(int id)
        {
            var car = _carsRepository.GetByIdWithIncludes(id, c => c.CarBasis);
            var brand = _brandRepository.GetByIdWithIncludes(car.CarBasis.BrandId, c => c.Manufacturer);
            return new CarDto()
            {
                Id = car.Id,
                RegistrationNumber = car.RegistrationNumber,
                BodyTypeNumber = car.BodyTypeNumber,
                EngineNumber = car.EngineNumber,
                BrandName = brand.BrandName,
                ManufacturerName = brand.Manufacturer.ManufacturerName,
                Picture = car.CarBasis.Picture,
                Color = car.CarBasis.Color,
                Price = Math.Round(car.CarBasis.Price, 2)
            };
        }
    }
}
