namespace CarDealershipManagement.Core.Models
{
    public class Brand : EntityBase
    {
        public string BrandName {  get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
