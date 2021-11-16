using CarDealershipManagement.Core.Dto.GatewayResponses.Repositories;
using CarDealershipManagement.Core.Models;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
    }
}
