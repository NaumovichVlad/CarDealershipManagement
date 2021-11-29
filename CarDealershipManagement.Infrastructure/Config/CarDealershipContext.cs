using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Config
{
    public class CarDealershipContext : IdentityDbContext<User>
    {
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<CarBasis> CarBasises => Set<CarBasis>();
        public DbSet<CarEquipment> CarEquipments => Set<CarEquipment>();
        public DbSet<CarSpecification> CarSpecifications => Set<CarSpecification>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
        public DbSet<OptionalEquipment> OptionalEquipments => Set<OptionalEquipment>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<Specification> Specifications => Set<Specification>();

        public CarDealershipContext(DbContextOptions<CarDealershipContext> options)
            : base(options)
        { }
    }
}
