using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealershipManagement.Infrastructure
{

    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<CarDealershipContext>(options =>
                options.UseSqlServer(connectionString));
    }
}
