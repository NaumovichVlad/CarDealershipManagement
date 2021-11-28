namespace CarDealershipManagement.Core.Models
{
    public class Employee : EntityBase
    {
        public string Surname {  get; set; }
        public string Name {  get; set; }
        public string MiddleName {  get; set; }
        public int PositionId {  get; set; }
        public string UserId {  get; set; }
        public User User {  get; set; }
        public Position Position {  get; set; }
    }
}
