﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JUDMB.Models
{
    public class LoginRequest
    {
        public string No_empleado { get; set; }
        public string Password { get; set; }
    }
}