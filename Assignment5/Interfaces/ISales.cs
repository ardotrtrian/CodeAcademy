using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Interfaces
{
    interface ISales                        //Might also be okay if we dont implement an interface for Sales class.
    {
        string ProductName { get; set; }
        DateTime Date { get; set; }
        double Price { get; set; }
    }
}
