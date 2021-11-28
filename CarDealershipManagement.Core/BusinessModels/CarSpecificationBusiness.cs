using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.BusinessModels
{
    public class CarSpecificationBusiness
    {
        public int CarId { get; set; }
        public int SpecificationId { get; set; }
        public string SpecificationName { get; set; }
        public double SpecificationValue { get; set; }
    }
}
