using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Models
{
    public class Specification : EntityBase
    {
        public string SpecificationName { get; set; }
        public double SpecificationValue {  get; set; }
    }
}
