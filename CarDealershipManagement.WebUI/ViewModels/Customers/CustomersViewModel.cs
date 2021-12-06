using CarDealershipManagement.WebUI.ViewModels.Main;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Customers
{
    public class CustomersViewModel
    {
        public List<CustomerViewModel> Customers { get; set; }
        public PageViewModel Page { get; set; }
    }
}
