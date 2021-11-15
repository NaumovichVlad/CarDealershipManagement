using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CarEquipmentsRepository : Repository<CarEquipment>
    {
        public CarEquipmentsRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
