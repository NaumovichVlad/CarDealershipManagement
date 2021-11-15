using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Models
{
    public class Employee : EntityBase
    {
        public string Surname {  get; set; }
        public string Name {  get; set; }
        public string MiddleName {  get; set; }
        public int PositionId {  get; set; }
        public int UserId {  get; set; }
        public User User {  get; set; }
        public Position Position {  get; set; }
    }
}
