using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Interfaces
{
    interface IManager : IEmployee
    {
        HashSet<IEmployee> ManagerOf { get; set; }
    }
}
