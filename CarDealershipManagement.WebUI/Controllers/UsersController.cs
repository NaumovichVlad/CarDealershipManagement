using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IIdentityService _identityService;

        public UsersController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            var users = _identityService.UsersList();
            return View(users.Select(u => new UserViewModel()
            {
                UserName = u.UserName,
                Roles = _identityService.GetUserRoles(u).Result.ToList()
            }).ToList());
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

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _identityService.GetUserById(id);
            if (user != null)
            {
                IdentityResult result = await _identityService.DeleteUser(user);
            }
            return RedirectToAction("Index");
        }*/
    }
}