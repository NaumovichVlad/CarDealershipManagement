using CarDealershipManagement.WebUI.ViewModels.CarsBasis;
using CarDealershipManagement.WebUI.ViewModels.CarsSpecifications;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Main
{
    public class CatalogViewModel
    {
        public CarBasisViewModel Car { get; set; }
        public List<CarSpecificationViewModel> Specifications { get; set; }
        public bool IsInStock { get; set; }
    }
}
