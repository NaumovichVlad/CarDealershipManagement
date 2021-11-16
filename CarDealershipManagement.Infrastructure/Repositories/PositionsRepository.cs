using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class PositionsRepository : Repository<Position>
    {
        public PositionsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
