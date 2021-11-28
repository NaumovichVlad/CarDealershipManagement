using CarDealershipManagement.Core.BusinessModels;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface ICarsService
    {
        List<CarBusiness> GetCars();
        CarBusiness GetCarById(int id);
        List<CarBusiness> GetCarsRange(int start, int end);
        int Count();
    }
}
