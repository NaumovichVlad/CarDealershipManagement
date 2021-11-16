using CarDealershipManagement.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Entities
{
    public class AppUser : IdentityUser, IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
