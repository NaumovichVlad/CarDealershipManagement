using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class CustomersRepository : Repository<Customer>
    {
        public CustomersRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
