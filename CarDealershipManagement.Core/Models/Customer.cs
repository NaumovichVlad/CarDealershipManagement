using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Models
{
    public class Customer : EntityBase
    {
        public string Surname {  get; set; }
        public string Name {  get; set; }
        public string MiddleName {  get; set; }
        public string PassportData {  get; set; }
        public string Address {  get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
