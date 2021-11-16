using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class EmployeesRepository : Repository<Employee>
    {
        public EmployeesRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
