using CarDealershipManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

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

        public CarDealershipContext (DbContextOptions<CarDealershipContext> options)
            : base(options)
        { }
    }
}
