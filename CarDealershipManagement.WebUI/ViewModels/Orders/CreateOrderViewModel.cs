using CarDealershipManagement.WebUI.ViewModels.Cars;
using CarDealershipManagement.WebUI.ViewModels.Customers;
using CarDealershipManagement.WebUI.ViewModels.Employees;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        public OrderViewModel Order { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
        public List<CustomerViewModel> Customers { get; set; }
        public List<CarViewModel> Cars { get; set; }
        public List<int> SelectedCustomerIds { get; set; }
        public List<int> SelectedEmployeeIds { get; set; }
        public List<int> SelectedCarIds { get; set; }
    }
}
