using Assignment5.Enums;
using Assignment5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Classes
{
    class Employee : Person, IEmployee
    {
        public double Salary { get; set; }
        public Department Department { get ; set ; }
        public override string ToString()
        {
            return $"{base.ToString()} , Department : {this.Department} , Salary : {this.Salary}";
        }
    }
}
