using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Interfaces.Repositories
{
    public interface IUserRoleRepository
    {
        Task<IdentityResult> AddUserRoleAsync(User user, string role);
        Task<IdentityResult> AddUserAsync(User user, string pasword);
        Task<IdentityResult> CreateRole(string roleName);
        Task<IdentityResult> DeleteRole(string id);
        List<User> UserList();
    }
}