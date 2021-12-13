using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Обеспечивает доступ к данным Ms Sql Server
    /// </summary>
    public class ManufacturersRepository : Repository<Manufacturer>
    {
        public ManufacturersRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
