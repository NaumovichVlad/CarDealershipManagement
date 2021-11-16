using Microsoft.AspNetCore.Identity;

namespace CarDealershipManagement.WebUI.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
