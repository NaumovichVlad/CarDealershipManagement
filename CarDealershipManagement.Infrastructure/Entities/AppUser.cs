using CarDealershipManagement.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CarDealershipManagement.Infrastructure.Entities
{
    public class AppUser : IdentityUser, IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
