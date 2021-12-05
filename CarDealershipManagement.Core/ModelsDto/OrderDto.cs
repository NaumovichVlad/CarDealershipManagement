using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.ModelsDto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string CarRegistrationNumber { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerName { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderCompleteMark { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? SaleDate { get; set; }
    }
}
