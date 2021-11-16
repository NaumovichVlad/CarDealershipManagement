using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class OptionalEquipmentsRepository : Repository<OptionalEquipment>
    {
        public OptionalEquipmentsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
