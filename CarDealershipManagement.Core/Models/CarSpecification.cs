namespace CarDealershipManagement.Core.Models
{
    public class CarSpecification : EntityBase
    {
        public int CarId {  get; set; }
        public Car Car {  get; set; }
        public int SpecificationId {  get; set; }
        public Specification Specification { get; set; }
    }
}
