using CarDealershipManagement.Core.BusinessModels;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class CatalogViewModel
    {
        public CarBusiness Car { get; set; }
        public List<CarSpecificationBusiness> Specifications { get; set; }
        public List<CarEquipmentBusiness> Equipments { get; set; }
        public PageViewModel Page { get; set; }

    }
}
