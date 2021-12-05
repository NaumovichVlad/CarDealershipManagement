using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<IdentityResult> AddNewUserRole(User user, string role);
        Task<IdentityResult> DeleteUserRole(User user, string role);
        Task<IdentityResult> AddNewUser(User user, string password);
        User GetUserByUserName(string userName);
        List<User> UsersList();
        List<IdentityRole> RolesList();
        Task<User> GetUserById(string id);
        Task<IList<string>> GetUserRoles(User user);
        Task<IdentityResult> DeleteUser(User user);
        Task<IdentityResult> UpdateUser(User user);
        Task<IdentityResult> CreateRole(string roleName);
        Task<IdentityResult> DeleteRole(string id);
    }
}