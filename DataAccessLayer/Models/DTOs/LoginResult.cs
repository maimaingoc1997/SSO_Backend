﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
    public class LoginResult
    {
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
