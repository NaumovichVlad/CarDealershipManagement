using System.Drawing;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class CarForCatalogViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ManufacturerName { get; set; }
        public Bitmap Picture { get; set; }
        public double Price { get; set; }
    }
}
