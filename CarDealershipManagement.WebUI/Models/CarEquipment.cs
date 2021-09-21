using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Models
{
    public class CarEquipment
    {
        public int CarEquipmentId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int EquipmentId { get; set; }
        public OptionalEquipment OptionalEquipment {  get; set;}
    }
}
