using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CarBasisesRepository : Repository<CarBasis>
    {
        public CarBasisesRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
