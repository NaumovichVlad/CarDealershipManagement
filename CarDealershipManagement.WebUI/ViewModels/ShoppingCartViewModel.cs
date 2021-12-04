using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public CustomerViewModel Customer { get; set; }
        public List<CarViewModel> Cars { get; set; }
    }
}
