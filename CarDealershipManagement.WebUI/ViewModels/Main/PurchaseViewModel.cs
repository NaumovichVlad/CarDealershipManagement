using CarDealershipManagement.WebUI.ViewModels.Cars;
using CarDealershipManagement.WebUI.ViewModels.CarsEquipments;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels.Main
{
    public class PurchaseViewModel
    {
        public CarViewModel Car { get; set; }
        public List<CarEquipmentViewModel> CarEquipments { get; set; }
    }
}
