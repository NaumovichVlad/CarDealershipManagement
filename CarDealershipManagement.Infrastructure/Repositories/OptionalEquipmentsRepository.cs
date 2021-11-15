using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class OptionalEquipmentsRepository : Repository<OptionalEquipment>
    {
        public OptionalEquipmentsRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
