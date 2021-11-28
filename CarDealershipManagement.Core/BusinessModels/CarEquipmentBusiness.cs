using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.BusinessModels
{
    public class CarEquipmentBusiness
    { 
        public int CarId { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public double EquipmentPrice { get; set; }
    }
}
