﻿using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealershipManagement.Infrastructure.Config
{
    /// <summary>
    /// Класс для создания инверсии зависимостей репозиториев
    /// </summary>
    public static class DependencyInjection
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CarDealershipContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Car>), typeof(CarsRepository));
            services.AddScoped(typeof(IRepository<CarBasis>), typeof(CarBasisesRepository));
            services.AddScoped(typeof(IRepository<Customer>), typeof(CustomersRepository));
            services.AddScoped(typeof(IRepository<Employee>), typeof(EmployeesRepository));
            services.AddScoped(typeof(IRepository<Order>), typeof(OrdersRepository));
            services.AddScoped(typeof(IRepository<CarEquipment>), typeof(CarEquipmentsRepository));
            services.AddScoped(typeof(IRepository<CarSpecification>), typeof(CarSpecificationsRepository));
            services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));
            services.AddScoped(typeof(IRepository<Brand>), typeof(BrandsRepository));
            services.AddScoped(typeof(IRepository<Manufacturer>), typeof(ManufacturersRepository));
            services.AddScoped(typeof(IRepository<Position>), typeof(PositionsRepository));
        }

        public static IdentityBuilder AddIdentity(this IServiceCollection services) =>
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<CarDealershipContext>();
    }
}
