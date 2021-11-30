using CarDealershipManagement.Core.ModelsDto;
using System.Collections.Generic;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class PurchaseViewModel
    {
        public CarDto Car { get; set; }
        public List<CarEquipmentDto> CarEquipments { get; set; }
    }
}
