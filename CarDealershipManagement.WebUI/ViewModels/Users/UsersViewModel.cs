using CarDealershipManagement.WebUI.ViewModels.Main;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Users
{
    public class UsersViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public PageViewModel Page { get; set; }
    }
}
