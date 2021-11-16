using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class SpecificationsRepository : Repository<Specification>
    {
        public SpecificationsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
