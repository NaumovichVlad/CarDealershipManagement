using CarDealershipManagement.Core.BusinessModels;
using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    public class CarSpecificationService : ICarSpecificationService
    {
        private readonly IRepository<CarSpecification> _repository;
        public CarSpecificationService(IRepository<CarSpecification> carSpecificationRepository)
        {
            _repository = carSpecificationRepository;
        }

        public List<CarSpecificationBusiness> GetCarEquipment()
        {
            var carSpecifications = _repository.List().Select(s => new CarSpecificationBusiness
            {
                CarId = s.CarId,
                SpecificationId = s.SpecificationId,
                SpecificationName = s.Specification.SpecificationName,
                SpecificationValue = s.Specification.SpecificationValue
            }).ToList();
            return carSpecifications;
        }

        public List<CarSpecificationBusiness> GetCarSpecificationsByCarId(int carId)
        {
            var carSpecifications = _repository.ListWithIncludes(s => s.CarId == carId, s => s.Specification)
                .Select(s => new CarSpecificationBusiness
            {
                CarId = s.CarId,
                SpecificationId = s.SpecificationId,
                SpecificationName = s.Specification.SpecificationName,
                SpecificationValue = s.Specification.SpecificationValue
            }).ToList();
            return carSpecifications;
        }
    }
}
