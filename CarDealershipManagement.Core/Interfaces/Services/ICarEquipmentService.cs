using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface ICarEquipmentService
    {
        List<CarEquipmentDto> GetCarEquipment();
        List<CarEquipmentDto> GetCarEquipmentsByCarId(int carId);
    }
}
