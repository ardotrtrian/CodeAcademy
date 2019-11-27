using Assignment5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Interfaces
{
    interface ISalesEmployee : IRegularEmployee
    {
        HashSet<ISales> Sales { get; set; }
    }
}
