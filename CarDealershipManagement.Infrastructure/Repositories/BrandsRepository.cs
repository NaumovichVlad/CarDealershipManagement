using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class BrandsRepository : Repository<Brand>
    {
        public BrandsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
