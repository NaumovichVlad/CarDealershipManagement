using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public UserRoleRepository(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Task<IdentityResult> CreateRole(string roleName)
        {
            return _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        public async Task<IdentityResult> DeleteRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role);
            return result;
        }
        public List<User> UserList() => _userManager.Users.ToList();
        public List<IdentityRole> RoleList() => _roleManager.Roles.ToList();
        public Task<IList<string>> UserRoleList(User user) => _userManager.GetRolesAsync(user);
        public Task<IdentityResult> AddUserRoleAsync(User user, string role)
        {
            return _userManager.AddToRoleAsync(user, role);
        }
        public Task<IdentityResult> DeleteUserRoleAsync(User user, string role)
        {
            return _userManager.RemoveFromRoleAsync(user, role);
        }

        public Task<IdentityResult> AddUserAsync(User user, string pasword)
        {
            return _userManager.CreateAsync(user, pasword);
        }

        public Task<User> GetUserByIdAsync(string id)
        {
            return _userManager.FindByIdAsync(id);
        }

        public Task<IdentityResult> DeleteUserAsync(User user)
        {
            return _userManager.DeleteAsync(user);
        }

        public Task<IdentityResult> UpdateUserAsync(User user)
        {
            return _userManager.UpdateAsync(user);
        }
    }
}