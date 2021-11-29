using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Config
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminUserName = "admin";
            string password = "Admin_01";
            string customerUserName = "testCustomerThree";
            string customerPassword = "testCustomer_3";
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
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(customer, "customer");
                }
            }
        }
        
    }
}
