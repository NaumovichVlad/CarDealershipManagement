using CarDealershipManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Config
{
    public class CarDealershipContext : DbContext
    {
        public DbSet<Brand> Brands {  get; set; }
        public DbSet<Car> Cars {  get; set; }
        public DbSet<CarEquipment> CarEquipments {  get; set; }
        public DbSet<CarSpecification> CarSpecifications {  get; set; }
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Employee> Employees {  get; set; }
        public DbSet<Manufacturer> Manufacturers {  get; set; }
        public DbSet<OptionalEquipment> OptionalEquipments {  get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<Position> Positions {  get; set; }
        public DbSet<Specification> Specifications {  get; set; }
        public DbSet<User> Users {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            dbContextOptionsBuilder.UseSqlServer(connectionString);
        }
    }
}
