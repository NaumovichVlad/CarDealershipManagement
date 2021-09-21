using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Models
{
    public class Specification
    {
        public int SpecificationId { get; set; }
        public string SpecificationName { get; set; }
        public double SpecificationValue {  get; set; }
    }
}
