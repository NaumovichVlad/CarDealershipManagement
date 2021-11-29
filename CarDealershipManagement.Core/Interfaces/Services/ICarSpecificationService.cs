using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface ICarSpecificationService
    {
        List<CarSpecificationDto> GetCarSpecifications();
        List<CarSpecificationDto> GetCarSpecificationsByCarId(int carId);
    }
}