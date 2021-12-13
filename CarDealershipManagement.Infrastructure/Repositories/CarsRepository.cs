using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Обеспечивает доступ к данным Ms Sql Server
    /// </summary>
    public class CarsRepository : Repository<Car>
    {
        public CarsRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
