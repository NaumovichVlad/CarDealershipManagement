using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Models
{
    public class CarSpecification
    {
        public int CarSpecificationId {  get; set; }
        public int CarId {  get; set; }
        public Car Car {  get; set; }
        public int SpecificationId {  get; set; }
        public Specification Specification { get; set; }
    }
}
