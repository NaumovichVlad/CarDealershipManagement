using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CarsRepository : Repository<Car>
    {
        public CarsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
