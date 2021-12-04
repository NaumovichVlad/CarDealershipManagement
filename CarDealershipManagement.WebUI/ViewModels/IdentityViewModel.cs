using CarDealershipManagement.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class IdentityViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
