using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class OrdersForEmployeeViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}
