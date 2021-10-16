using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Entities
{
    public class OptionalEquipment : EntityBase
    {
        public string EquipmentName { get; set; }
        public double Price { get; set; }
    }
}
