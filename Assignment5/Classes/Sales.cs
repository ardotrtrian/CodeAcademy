﻿using Assignment5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Classes
{
    class Sales : ISales
    {
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
