using CarDealershipManagement.Core.BusinessModels;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface ICarSpecificationService
    {
        List<CarSpecificationBusiness> GetCarEquipment();
        List<CarSpecificationBusiness> GetCarSpecificationsByCarId(int carId);
    }
}