using Assignment5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Classes
{
    class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public HashSet<ISales> Sales { get; set; }

        public override string ToString()
        {
            return $"{ base.ToString()}, Employee Type : {this.GetType().BaseType.Name} , Number Of Sales he has done : { (Sales != null ? Sales.Count : 0)} ";
        }
    }
}
