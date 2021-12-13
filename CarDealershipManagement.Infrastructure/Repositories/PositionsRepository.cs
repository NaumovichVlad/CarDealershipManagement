using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Обеспечивает доступ к данным Ms Sql Server
    /// </summary>
    public class PositionsRepository : Repository<Position>
    {
        public PositionsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
