using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Interfaces
{
    interface ICustomer : IPerson
    {
        double NetPurchaseAmount { get; set; }
    }
}
