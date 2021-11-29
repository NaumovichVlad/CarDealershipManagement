using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface ICarBasisService
    {
        List<CarBasisDto> GetCars();
        CarBasisDto GetCarById(int id);
        List<CarBasisDto> GetCarsRange(int start, int end);
        int Count();
    }
}
