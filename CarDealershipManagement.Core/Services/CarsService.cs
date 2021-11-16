using CarDealershipManagement.Core.BusinessModels;
using CarDealershipManagement.Core.Interfaces;
using CarDealershipManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var cars = _carsRepository.Take(10).Select(c =>
            new CarBusiness()
            {
                Id = c.Id,
                RegistrationNumber = c.RegistrationNumber,
                BrandName = c.Brand.BrandName,
                ManufacturerName = c.Manufacturer.ManufacturerName,
                Picture = InitializeImage(c.Picture),
                Color = c.Color,
                BodyTypeNumber = c.BodyTypeNumber,
                EngineNumber = c.EngineNumber,
                Price = c.Price,
            });
            return cars.ToList();
        }

        
        private static Image InitializeImage(byte[] imageBytes)
        {
            using var ms = new MemoryStream(imageBytes);
            return Image.FromStream(ms);
        }
    }
}
