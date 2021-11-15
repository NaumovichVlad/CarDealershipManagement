using System.Drawing;

namespace CarDealershipManagement.Core.BusinessModels
{
    public class CarBusiness
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string BrandName { get; set; }
        public string ManufacturerName { get; set; }
        public Bitmap Picture { get; set; }
        public string Color { get; set; }
        public string BodyTypeNumber { get; set; }
        public string EngineNumber { get; set; }
        public double Price { get; set; }
    }
}
