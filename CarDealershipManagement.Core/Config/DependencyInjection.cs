using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealershipManagement.Core.Config
{
    /// <summary>
    /// Класс для добавления инверсии зависимостей в сервисы
    /// </summary>
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICarBasisService, CarBasisService>();
            services.AddTransient<ICarEquipmentService, CarEquipmentService>();
            services.AddTransient<ICarSpecificationService, CarSpecificationService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IPositionService, PositionService>();
        }
    }
}
