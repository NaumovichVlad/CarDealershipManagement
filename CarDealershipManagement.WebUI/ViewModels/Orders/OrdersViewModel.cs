using CarDealershipManagement.WebUI.ViewModels.Main;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Orders
{
    public class OrdersViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public PageViewModel Page { get; set; }
    }
}
