using CarDealershipManagement.Core.Dto;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}
