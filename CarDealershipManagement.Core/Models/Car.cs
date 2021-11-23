using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Models
{
    public class Car : EntityBase
    {
        public string RegistrationNumber {  get; set; }
        public int BrandId {  get; set; }
        public Brand Brand { get; set; }
        public int ManufacturerId {  get; set; }
        public Manufacturer Manufacturer { get; set; }
        public byte[] Picture {  get; set; }
        public string Color {  get; set; }
        public string BodyTypeNumber {  get; set; }
        public string EngineNumber {  get; set; }
        public double Price {  get; set; }
    }
}
