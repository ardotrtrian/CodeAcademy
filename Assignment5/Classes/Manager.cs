using Assignment5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Classes
{
    class Manager : Employee, IManager
    {
        public HashSet<IEmployee> ManagerOf { get; set; } 

        public override string ToString()
        {
            return $"{base.ToString()} , Number Of Employees under his command : { (ManagerOf != null ? ManagerOf.Count : 0 ) }";
        }
    }
}
