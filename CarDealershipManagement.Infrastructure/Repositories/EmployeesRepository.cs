using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Обеспечивает доступ к данным Ms Sql Server
    /// </summary>
    public class EmployeesRepository : Repository<Employee>
    {
        public EmployeesRepository(CarDealershipContext dbContext) : base(dbContext)
        { }
    }
}
