using CarDealershipManagement.Core.Interfaces.Services;
using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Core.ModelsDto;
using CarDealershipManagement.WebUI.Extensions;
using CarDealershipManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IIdentityService _identityService;

        public AccountController(SignInManager<User> signInManager, IIdentityService identityService)
        {
            _signInManager = signInManager;
            _identityService = identityService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new() { UserName = model.UserName };
                var customer = new CustomerDto()
                {
                    Surname = model.Surname,
                    Name = model.Name,
                    MiddleName = model.MiddleName,
                    Address = model.Address,
                    PassportData = model.PassportData,
                };
                var result = _identityService.AddNewUser(user, model.Password, customer).Result;
                if (result.Succeeded)
                {
                    IdentityResult tmpResult = _identityService.AddNewUserRole(user, "customer").Result;
                    if (tmpResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in tmpResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
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

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
    
}
