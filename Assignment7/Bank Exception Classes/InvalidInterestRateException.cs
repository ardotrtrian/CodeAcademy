using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Bank_Exception_Classes
{
    class InvalidInterestRateException : BankAccountException
    {
        public override string Message
        {
            get
            {
                return "Interest rate is not in range of [ 0.0 , 22.0 ] !";
            }
        }

        public InvalidInterestRateException()
            : base()
        {
        }
        public InvalidInterestRateException(string message)
            : base(message)
        {
        }
        public InvalidInterestRateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
