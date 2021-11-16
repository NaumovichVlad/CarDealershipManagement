using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CarEquipmentsRepository : Repository<CarEquipment>
    {
        public CarEquipmentsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
