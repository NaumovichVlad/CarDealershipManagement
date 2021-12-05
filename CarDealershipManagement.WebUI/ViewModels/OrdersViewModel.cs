using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class OrdersViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public PageViewModel Page { get; set; }
    }
}
