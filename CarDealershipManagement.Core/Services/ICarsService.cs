using CarDealershipManagement.Core.BusinessModels;
using System.Collections.Generic;

namespace CarDealershipManagement.Core.Services
{
    public interface ICarsService
    {
        List<CarBusiness> GetCars();
    }
}
