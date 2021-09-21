﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Models
{
    public class Order
    {
        public int OrderId {  get; set; }
        public int CustomerId {  get; set; }
        public Customer Customer {  get; set; }
        public int CarId {  get; set; }
        public Car Car {  get; set; }
        public int EmployeeId {  get; set; }
        public Employee Employee {  get; set; }
        public DateTime OrderDate {  get; set; }
        public bool OrderCompleteMark {  get; set; }
        public DateTime SaleDate {  get; set; }
        public double PrePayment {  get; set; }
    }
}
