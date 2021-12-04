using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class CatalogViewModel
    {
        public CarBasisViewModel Car { get; set; }
        public List<CarSpecificationViewModel> Specifications { get; set; }
        public bool IsInStock { get; set; }
    }
}
