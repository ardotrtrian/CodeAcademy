using Assignment5.Enums;
using Assignment5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Classes
{
    class Project : IProject
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Details { get; set; }
        public State State { get; set; }
    }
}
