using Assignment5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Classes
{
    class Customer : Person, ICustomer
    {
        public double NetPurchaseAmount { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} , Net Purchase Amount : {this.NetPurchaseAmount}";
        }
    }
}
