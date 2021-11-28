using CarDealershipManagement.Core.BusinessModels;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface ICarEquipmentService
    {
        List<CarEquipmentBusiness> GetCarEquipment();
        List<CarEquipmentBusiness> GetCarEquipmentsByCarId(int carId);
    }
}
