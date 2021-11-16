using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class ManufacturersRepository : Repository<Manufacturer>
    {
        public ManufacturersRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
