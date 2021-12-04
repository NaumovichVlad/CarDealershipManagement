using System;

namespace CarDealershipManagement.Core.Models
{
    public class Order : EntityBase
    {
        public int CustomerId {  get; set; }
        public Customer Customer {  get; set; }
        public int CarId {  get; set; }
        public Car Car {  get; set; }
        public int? EmployeeId {  get; set; }
        public Employee Employee {  get; set; }
        public DateTime OrderDate {  get; set; }
        public bool OrderCompleteMark {  get; set; }
        public bool IsApproved { get; set; }
        public DateTime? SaleDate {  get; set; }
    }
}
