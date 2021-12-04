using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class PurchaseViewModel
    {
        public CarViewModel Car { get; set; }
        public List<CarEquipmentViewModel> CarEquipments { get; set; }
    }
}
