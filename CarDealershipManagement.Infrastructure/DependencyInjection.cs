﻿using AutoMapper;
using CarDealershipManagement.Core.Interfaces;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using CarDealershipManagement.Infrastructure.Entities;
using CarDealershipManagement.Infrastructure.Mapping;
using CarDealershipManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealershipManagement.Infrastructure
{

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
            services.AddScoped(typeof(IRepository<Customer>), typeof(CustomersRepository));
            services.AddScoped(typeof(IRepository<Employee>), typeof(EmployeesRepository));
            services.AddScoped(typeof(IRepository<Order>), typeof(OrdersRepository));
        }

        public static void AddUserMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static IdentityBuilder AddIdentity(this IServiceCollection services) =>
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<CarDealershipContext>();
    }
}
