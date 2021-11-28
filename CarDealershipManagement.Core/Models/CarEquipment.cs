namespace CarDealershipManagement.Core.Models
{
    public class CarEquipment : EntityBase
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int OptionalEquipmentId { get; set; }
        public OptionalEquipment OptionalEquipment {  get; set;}
    }
}
