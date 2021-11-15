using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class BrandsRepository : Repository<Brand>
    {
        public BrandsRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
