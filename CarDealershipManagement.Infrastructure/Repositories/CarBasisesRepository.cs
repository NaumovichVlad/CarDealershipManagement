using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Обеспечивает доступ к данным Ms Sql Server
    /// </summary>
    public class CarBasisesRepository : Repository<CarBasis>
    {  
        public CarBasisesRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
