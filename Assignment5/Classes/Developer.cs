using Assignment5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Classes
{
    class Developer : RegularEmployee, IDeveloper
    {
        public HashSet<IProject> Projects { get; set; } 
        public override string ToString()
        {
            return $"{base.ToString()} Employee Type : {this.GetType().BaseType.Name} , Number Of Project he is currently working on :" +
                $" { (Projects != null ? Projects.Where(p => p.State == Enums.State.Open).Count() : 0)} ";
        }
    }
}
