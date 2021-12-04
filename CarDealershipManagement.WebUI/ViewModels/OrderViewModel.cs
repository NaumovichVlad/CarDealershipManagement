using System;

namespace CarDealershipManagement.WebUI.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderCompleteMark { get; set; }
        public bool IsApproved { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
