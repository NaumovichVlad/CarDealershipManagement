using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Обеспечивает доступ к данным Ms Sql Server
    /// </summary>
    public class OrdersRepository : Repository<Order>
    {
        public OrdersRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
