namespace CarDealershipManagement.Core.Models
{
    public class Car : EntityBase
    {
        public string RegistrationNumber { get; set; }
        public string BodyTypeNumber { get; set; }
        public string EngineNumber { get; set; }
        public int CarBasisId { get; set; }
        public CarBasis CarBasis { get; set; }
    }
}
