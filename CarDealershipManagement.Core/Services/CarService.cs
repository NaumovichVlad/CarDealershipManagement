using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carsRepository;
        private readonly IRepository<Order> _orderRepository;
        public CarService(IRepository<Car> carsRepository, IRepository<Order> orderRepository)
        {
            _carsRepository = carsRepository;
            _orderRepository = orderRepository;
        }

        public List<CarDto> GetCars()
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
                }).ToList();
        }
        public bool CheckIsFree(int carBasisId)
        {
            var cars = _carsRepository.List(c => c.CarBasisId == carBasisId).Select(c => c.Id);
            if (!cars.Any())
                return false;
            var orders = _orderRepository.List(o => cars.Contains(o.CarId)).Count();
            return !(cars.Count() == orders) ;
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
            IEnumerable<Car> cars;
            if(orders.Any())
                cars = _carsRepository.ListWithIncludes(c => c.CarBasis.Id == carBasisId && !orders.Contains(c.Id),
                    c => c.CarBasis, c => c.CarBasis.Brand, c => c.CarBasis.Brand.Manufacturer);
            else
                cars = _carsRepository.ListWithIncludes(c => c.CarBasis.Id == carBasisId,
                    c => c.CarBasis, c => c.CarBasis.Brand, c => c.CarBasis.Brand.Manufacturer);
            if (cars.Any())
            {
                var car = cars.First();
                return new CarDto()
                {
                    Id = car.Id,
                    RegistrationNumber = car.RegistrationNumber,
                    BodyTypeNumber = car.BodyTypeNumber,
                    EngineNumber = car.EngineNumber,
                    BrandName = car.CarBasis.Brand.BrandName,
                    ManufacturerName = car.CarBasis.Brand.Manufacturer.ManufacturerName,
                    Picture = car.CarBasis.Picture,
                    Color = car.CarBasis.Color,
                    Price = Math.Round(car.CarBasis.Price, 2)
                };
            }
            else return null;
                
        }
    }
}
