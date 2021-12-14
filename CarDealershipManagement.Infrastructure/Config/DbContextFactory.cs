using Microsoft.EntityFrameworkCore;


namespace CarDealershipManagement.Infrastructure.Config
{
    /// <summary>
    /// Фабрика для создания подключеня к бд
    /// </summary>
    public class DbContextFactory : DesignTimeDbContextFactoryBase<CarDealershipContext>
    {
        protected override CarDealershipContext CreateNewInstance(DbContextOptions<CarDealershipContext> options)
        {
            return new CarDealershipContext(options);
        }
    }
}
