using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CarSpecificationsRepository : Repository<CarSpecification>
    {
        public CarSpecificationsRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
