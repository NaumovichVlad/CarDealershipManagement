using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Models
{
    public class CarEquipment : EntityBase
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int EquipmentId { get; set; }
        public OptionalEquipment OptionalEquipment {  get; set;}
    }
}
