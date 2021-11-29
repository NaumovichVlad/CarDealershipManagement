using CarDealershipManagement.Core.Config;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Middleware
{
    public class DbTestInitializerMiddleware
    {

        private readonly RequestDelegate _next;
        public DbTestInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context, IServiceProvider serviceProvider, CarDealershipContext dbContext)
        {
            InitializeDb(dbContext);
            return _next.Invoke(context);
        }

        private static void InitializeDb(CarDealershipContext db)
        {
            db.Database.EnsureCreated();

            if (db.Cars.Any())
                return;

            
            db.Manufacturers.AddRange(DbTestFiller.GetTestManufacturers());
            db.SaveChanges();
            db.Brands.AddRange(DbTestFiller.GetTestBrands());
            db.SaveChanges();
            db.Positions.AddRange(DbTestFiller.GetTestPositions());
            db.SaveChanges();
            db.Employees.AddRange(DbTestFiller.GetTestEmployees());
            db.SaveChanges();
            db.OptionalEquipments.AddRange(DbTestFiller.GetTestOptionalEquipments());
            db.SaveChanges();
            db.Specifications.AddRange(DbTestFiller.GetTestSpecifications());
            db.SaveChanges();
            db.CarBasises.AddRange(DbTestFiller.GetTestCarsBasis());
            db.SaveChanges();
            db.Cars.AddRange(DbTestFiller.GetTestCars());
            db.SaveChanges();
            db.CarEquipments.AddRange(DbTestFiller.GetTestCarEquipments());
            db.SaveChanges();
            db.CarSpecifications.AddRange(DbTestFiller.GetTestCarSpecifications());
            db.SaveChanges();
            db.Customers.AddRange(DbTestFiller.GetTestCustomers());
            db.SaveChanges();
            db.Orders.AddRange(DbTestFiller.GetTestOrders());
            db.SaveChanges();
        }

    }

    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbTestInitializerMiddleware>();
        }

    }
}
