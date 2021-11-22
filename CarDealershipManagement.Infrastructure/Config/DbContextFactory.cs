using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
 

namespace CarDealershipManagement.Infrastructure.Config
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<CarDealershipContext>
    {
        protected override CarDealershipContext CreateNewInstance(DbContextOptions<CarDealershipContext> options)
        {
            return new CarDealershipContext(options);
        }
    }
}
