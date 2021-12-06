using CarDealershipManagement.Core.Models;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Middleware
{
    public class RoleInitializerMiddleware
    {
        private readonly RequestDelegate _next;
        public RoleInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context, IServiceProvider services, CarDealershipContext dbContext)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            InitializeAsync(userManager, rolesManager, dbContext).Wait();
            return _next.Invoke(context);
        }

        public static async Task InitializeAsync(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, CarDealershipContext dbContext)
        {
            string adminUserName = "testAdmin";
            string password = "testAdmin_01";
            string customerUserName = "testCustomer";
            string customerPassword = "testCustomer_01";
            string employeeUserName = "testEmployee";
            string employeePassword = "testEmployee_01";

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
            if (await userManager.FindByNameAsync(customerUserName) == null)
            {
                User customer = new() { UserName = customerUserName };
                IdentityResult result = await userManager.CreateAsync(customer, customerPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(customer, "customer");
                    var customerDb = userManager.GetUsersInRoleAsync("customer").Result.First();
                    dbContext.Customers.First().UserId = customerDb.Id;
                    dbContext.SaveChanges();
                }
            }
            if (await userManager.FindByNameAsync(employeeUserName) == null)
            {
                User employee = new() { UserName = employeeUserName };
                IdentityResult result = await userManager.CreateAsync(employee, employeePassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee, "employee");
                    var employeeDb = userManager.GetUsersInRoleAsync("employee").Result.First();
                    dbContext.Employees.First().UserId = employeeDb.Id;
                    dbContext.SaveChanges();
                }
            }
        }
    }


    public static class RoleInitializerExtensions
    {
        public static IApplicationBuilder UseRoleInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoleInitializerMiddleware>();
        }

    }
}
