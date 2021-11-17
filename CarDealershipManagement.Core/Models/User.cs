﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Models
{
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string Password {  get; set; }
        public bool IsAdmin {  get; set; }

    }
}
