﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipManagement.Core.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password {  get; set; }
        public bool IsAdmin {  get; set; }

    }
}
