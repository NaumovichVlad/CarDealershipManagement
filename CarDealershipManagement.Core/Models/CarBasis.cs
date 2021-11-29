using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Models
{
    public class CarBasis : EntityBase
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public byte[] Picture { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}
