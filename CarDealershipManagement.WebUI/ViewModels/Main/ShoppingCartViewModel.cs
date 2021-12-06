using CarDealershipManagement.WebUI.ViewModels.Cars;
using CarDealershipManagement.WebUI.ViewModels.Customers;
using CarDealershipManagement.WebUI.ViewModels.Orders;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Main
{
    public class ShoppingCartViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public CustomerViewModel Customer { get; set; }
        public List<CarViewModel> Cars { get; set; }
    }
}
