﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Infrastructure.Entities
{
    public class Manufacturer : EntityBase
    {
        public string ManufacturerName { get; set; }
        public string Adress {  get; set; }
        public string Description {  get; set; }
    }
}