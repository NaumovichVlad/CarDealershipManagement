using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Entities
{
    public class Customer : EntityBase
    {
        public string Surname {  get; set; }
        public string Name {  get; set; }
        public string MiddleName {  get; set; }
        public string PassportData {  get; set; }
        public string Address {  get; set; }
    }
}
