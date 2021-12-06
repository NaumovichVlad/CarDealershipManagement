using CarDealershipManagement.WebUI.ViewModels.CarsBasis;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Main
{
    public class SearchViewModel
    {
        public List<CarBasisViewModel> Cars { get; set; }
        public PageViewModel Page { get; set; }
    }
}
