using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Entities
{
    public class CarEquipment : EntityBase
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int EquipmentId { get; set; }
        public OptionalEquipment OptionalEquipment {  get; set;}
    }
}
