using Assignment5.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Interfaces
{
    interface IEmployee : IPerson
    {
        double Salary { get; set; }
        Department Department { get; set; }
    }
}
