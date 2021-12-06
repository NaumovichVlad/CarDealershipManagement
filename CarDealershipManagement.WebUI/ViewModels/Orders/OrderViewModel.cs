using System;

namespace CarDealershipManagement.WebUI.ViewModels.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string CarRegistrationNumber { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderCompleteMark { get; set; }
        public bool IsApproved { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
