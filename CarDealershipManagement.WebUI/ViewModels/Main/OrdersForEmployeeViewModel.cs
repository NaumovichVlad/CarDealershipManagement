using CarDealershipManagement.WebUI.ViewModels.Employees;
using CarDealershipManagement.WebUI.ViewModels.Orders;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Main
{
    public class OrdersForEmployeeViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}
