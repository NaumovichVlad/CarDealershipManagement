using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly IIdentityService _identityService;
        private const int _pageSize = 10;

        public UsersController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            var users = _identityService.UsersList();
            var count = users.Count;
            users = users.Skip((pageNumber - 1) * _pageSize).Take(_pageSize).ToList();
            var page = new PageViewModel(count, pageNumber, _pageSize);
            var usersView = users.Select(u => new UserViewModel()
            {
                UserId = u.Id,
                UserName = u.UserName,
                UserRoles = _identityService.GetUserRoles(u).Result.ToList(),
                AllRoles = _identityService.RolesList()
            }).ToList();
            return View(new UsersViewModel()
            {
                Users = usersView,
                Page = page
            });
        }

        public async Task<IActionResult> EditRole(string userId)
        {
            User user = await _identityService.GetUserById(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _identityService.GetUserRoles(user);
                var allRoles = _identityService.RolesList();
                UserViewModel model = new()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(string userId, List<string> roles)
        {
            User user = await _identityService.GetUserById(userId);
            if (user != null)
            {
                var userRoles = _identityService.GetUserRoles(user).Result.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                foreach (var role in addedRoles)
                    await _identityService.AddNewUserRole(user, role);

                foreach (var role in removedRoles)
                    await _identityService.DeleteUserRole(user, role);

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        public async Task<ActionResult> Delete(string id)
        {
            User user = await _identityService.GetUserById(id);
            if (user != null)
            {
                _ = await _identityService.DeleteUser(user);
            }
            return RedirectToAction("Index");
        }
        /*public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.UserName};
                var result = await _identityService.AddNewUser(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await _identityService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, Year = user.Year };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _identityService.GetUserById(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    var result = await _identityService.UpdateUser(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        */
    }
}