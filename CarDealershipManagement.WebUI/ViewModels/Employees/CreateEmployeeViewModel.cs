using CarDealershipManagement.WebUI.ViewModels.Positions;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Employees
{
    public class CreateEmployeeViewModel
    {
        public EmployeeViewModel Employee { get; set; }
        public List<PositionViewModel> Positions { get; set; }
        public IEnumerable<int> SelectedPositionIds { get; set; }
    }
}
