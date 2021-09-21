using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Models
{
    public class Employee
    {
        public int EmployeeId {  get; set; }
        public string Surname {  get; set; }
        public string Name {  get; set; }
        public string MiddleName {  get; set; }
        public int PositionId {  get; set; }
        public Position Position {  get; set; }
    }
}
