using CarDealershipManagement.Core.Interfaces.Repositories;
using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public IdentityService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public Task<IdentityResult> AddNewUserRole(User user, string role)
        {
            return _userRoleRepository.AddUserRoleAsync(user, role);
        }

        public Task<IdentityResult> DeleteUserRole(User user, string role)
        {
            return _userRoleRepository.DeleteUserRoleAsync(user, role);
        }

        public Task<IdentityResult> AddNewUser(User user, string password)
        {
             return _userRoleRepository.AddUserAsync(user, password);
        }

        public Task<IdentityResult> DeleteUser(User user)
        {
            return _userRoleRepository.DeleteUserAsync(user);
        }

        public List<User> UsersList() => _userRoleRepository.UserList();

        public List<IdentityRole> RolesList() => _userRoleRepository.RoleList();

        public User GetUserByUserName(string userName)
        {
            return _userRoleRepository.UserList().Find(u => u.UserName == userName);
        }

        public Task<User> GetUserById(string id)
        {
            return _userRoleRepository.GetUserByIdAsync(id);
        }

        public async Task<IList<string>> GetUserRoles(User user)
        {
            return await _userRoleRepository.UserRoleList(user);
        }

        public Task<IdentityResult> UpdateUser(User user)
        {
            return _userRoleRepository.UpdateUserAsync(user);
        }

        public Task<IdentityResult> CreateRole(string roleName)
        {
            return _userRoleRepository.CreateRole(roleName);
        }

        public Task<IdentityResult> DeleteRole(string id)
        {
            return _userRoleRepository.DeleteRole(id);
        }
    }
}
