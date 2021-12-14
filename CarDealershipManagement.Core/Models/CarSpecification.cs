namespace CarDealershipManagement.Core.Models
{
    public class CarSpecification : EntityBase
    {
        public int CarBasisId { get; set; }
        public CarBasis CarBasis { get; set; }
        public int SpecificationId { get; set; }
        public Specification Specification { get; set; }
    }
}
