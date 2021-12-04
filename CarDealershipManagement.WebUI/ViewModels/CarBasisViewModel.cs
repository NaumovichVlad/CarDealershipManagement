namespace CarDealershipManagement.WebUI.ViewModels
{
    public class CarBasisViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ManufacturerName { get; set; }
        public byte[] Picture { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}
