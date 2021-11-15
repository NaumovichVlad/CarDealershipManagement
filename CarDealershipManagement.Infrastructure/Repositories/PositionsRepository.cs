using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class PositionsRepository : Repository<Position>
    {
        public PositionsRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
