using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Обеспечивает доступ к данным Ms Sql Server
    /// </summary>
    public class CarSpecificationsRepository : Repository<CarSpecification>
    {
        public CarSpecificationsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
