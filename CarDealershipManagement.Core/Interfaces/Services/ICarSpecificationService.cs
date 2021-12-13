using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для взаимодействия с сервисом
    /// </summary>
    public interface ICarSpecificationService
    {
        List<CarSpecificationDto> GetCarSpecifications();
        List<CarSpecificationDto> GetCarSpecificationsByCarId(int carId);
    }
}