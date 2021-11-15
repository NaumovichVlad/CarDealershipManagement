using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class EmployeesRepository : Repository<Employee>
    {
        public EmployeesRepository(DbContextOptions<CarDealershipContext> options) : base(options)
        { }
    }
}
