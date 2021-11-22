using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Middleware
{
    public class RoleInitializerMiddleWare
    {
        private readonly RequestDelegate _next;
        public RoleInitializerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task<Task> InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            await InitializeAsync(serviceProvider);
            return _next.Invoke(context);
        }
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string adminUserName = "admin";
            string password = "Admin_01";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("employee") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("employee"));
            }
            if (await roleManager.FindByNameAsync("customer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }
            if (await userManager.FindByNameAsync(adminUserName) == null)
            {
                User admin = new() { UserName = adminUserName };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
        
    }

    public static class RoleInitializerExtensions
    {
        public static IApplicationBuilder UseRoleInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoleInitializerMiddleWare>();
        }

    }
}
