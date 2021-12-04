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
        List<IdentityRole> RoleList();
        Task<IList<string>> UserRoleList(User user);
        Task<User> GetUserByIdAsync(string id);
        Task<IdentityResult> DeleteUserAsync(User user);
        Task<IdentityResult> UpdateUserAsync(User user);
    }
}