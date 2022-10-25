﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Organization
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public List<Rent> rents { get; set; }
    }
}
