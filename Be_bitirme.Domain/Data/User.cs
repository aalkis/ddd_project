﻿using Be_bitirme.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Domain.Data
{
    public class User 
    {
        

        public int? UserId { get; set; }
        public string? Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? City { get; set; }
        public string? Password { get; set; }
        public int? UserStatus { get; set; }
        public Basket? Basket { get; set; }

    }
}
