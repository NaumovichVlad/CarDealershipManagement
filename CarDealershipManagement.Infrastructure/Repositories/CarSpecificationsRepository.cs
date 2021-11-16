using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CarSpecificationsRepository : Repository<CarSpecification>
    {
        public CarSpecificationsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
