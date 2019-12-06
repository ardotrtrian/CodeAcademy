using Assignment5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Interfaces
{
    interface IDeveloper : IRegularEmployee         //Might also be okay if we dont implement an interface for Developer class.
    {
        HashSet<IProject> Projects { get; set; }
    }
}
