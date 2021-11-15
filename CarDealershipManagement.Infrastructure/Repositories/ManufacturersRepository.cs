using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class ManufacturersRepository : Repository<Manufacturer>
    {
        public ManufacturersRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
