using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class CatalogViewModel
    {
        public CarBasisDto Car { get; set; }
        public List<CarSpecificationDto> Specifications { get; set; }
        public bool IsInStock { get; set; }

    }
}
