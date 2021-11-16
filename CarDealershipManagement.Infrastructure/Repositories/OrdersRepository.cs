using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class OrdersRepository : Repository<Order>
    {
        public OrdersRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
