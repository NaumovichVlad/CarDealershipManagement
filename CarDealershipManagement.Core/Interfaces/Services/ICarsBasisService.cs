using CarDealershipManagement.Core.BusinessModels;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface ICarsBasisService
    {
        List<CarBasisBusiness> GetCars();
        CarBasisBusiness GetCarById(int id);
        List<CarBasisBusiness> GetCarsRange(int start, int end);
        int Count();
    }
}
