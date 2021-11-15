using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CarsRepository : Repository<Car>
    {
        public CarsRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
