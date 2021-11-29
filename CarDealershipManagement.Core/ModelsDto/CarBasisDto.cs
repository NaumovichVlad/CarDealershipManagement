using System.Drawing;

namespace CarDealershipManagement.Core.ModelsDto
{
    public class CarBasisDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ManufacturerName { get; set; }
        public byte[] Picture { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}
