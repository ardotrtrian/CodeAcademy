using Assignment5.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Interfaces
{
    interface IProject                  //Might also be okay if we dont implement an interface for Project class.
    {
        string Name { get; set; }
        DateTime StartDate { get; set; }
        string Details { get; set; }
        State State { get; set; } 
    }
}
