using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CustomersRepository : Repository<Customer>
    {
        public CustomersRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
