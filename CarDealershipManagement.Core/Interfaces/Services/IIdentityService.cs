using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<IdentityResult> AddNewUserRole(User user, string role);
        Task<IdentityResult> AddNewUser(User user, string password);
        User GetUserByUserName(string userName);
    }
}