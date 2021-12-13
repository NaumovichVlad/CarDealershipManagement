using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для взаимодействия с сервисом
    /// </summary>
    public interface ICarService
    {
        IEnumerable<CarDto> GetCars();
        List<CarDto> GetCarsByCarBasisId(int carBasisId);
        CarDto GetFreeCarByCarBasisId(int carBasisId);
        bool CheckIsFree(int carBasisId);
        CarDto GetCarById(int id);
    }
}