using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Models
{
    public class Customer
    {
        public int CustomerId {  get; set; }
        public string Surname {  get; set; }
        public string Name {  get; set; }
        public string MiddleName {  get; set; }
        public string PassportData {  get; set; }
        public string Address {  get; set; }
    }
}
