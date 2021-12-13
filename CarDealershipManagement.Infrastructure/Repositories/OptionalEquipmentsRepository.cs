using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Обеспечивает доступ к данным Ms Sql Server
    /// </summary>
    public class OptionalEquipmentsRepository : Repository<OptionalEquipment>
    {
        public OptionalEquipmentsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
