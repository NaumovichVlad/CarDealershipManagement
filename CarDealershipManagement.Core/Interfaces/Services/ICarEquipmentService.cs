using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для взаимодействия с сервисом
    /// </summary>
    public interface ICarEquipmentService
    {
        List<CarEquipmentDto> GetCarEquipment();
        List<CarEquipmentDto> GetCarEquipmentsByCarId(int carId);
    }
}
