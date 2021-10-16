using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Entities
{
    public class Specification : EntityBase
    {
        public string SpecificationName { get; set; }
        public double SpecificationValue {  get; set; }
    }
}
