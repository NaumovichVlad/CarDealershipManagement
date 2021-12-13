using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipManagement.Core.Services
{
    /// <summary>
    /// Сервис для раьоты с репозиторием
    /// </summary>
    public class CarSpecificationService : ICarSpecificationService
    {
        private readonly IRepository<CarSpecification> _repository;
        public CarSpecificationService(IRepository<CarSpecification> carSpecificationRepository)
        {
            _repository = carSpecificationRepository;
        }

        public List<CarSpecificationDto> GetCarSpecifications()
        {
            var carSpecifications = _repository.List().Select(s => new CarSpecificationDto
            {
                CarId = s.CarBasisId,
                SpecificationId = s.SpecificationId,
                SpecificationName = s.Specification.SpecificationName,
                SpecificationValue = s.Specification.SpecificationValue
            }).ToList();
            return carSpecifications;
        }

        public List<CarSpecificationDto> GetCarSpecificationsByCarId(int carId)
        {
            var carSpecifications = _repository.ListWithIncludes(s => s.CarBasisId == carId, s => s.Specification)
                .Select(s => new CarSpecificationDto
            {
                CarId = s.CarBasisId,
                SpecificationId = s.SpecificationId,
                SpecificationName = s.Specification.SpecificationName,
                SpecificationValue = s.Specification.SpecificationValue
            }).ToList();
            return carSpecifications;
        }
    }
}
