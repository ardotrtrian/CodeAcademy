using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Bank_Exception_Classes
{
    class NegativeAmountException : BankAccountException
    {
        public override string Message
        {
            get
            {
                return "Amount can not be a negative value!";
            }
        }

        public NegativeAmountException()
            : base()
        {
        }
        public NegativeAmountException(string message)
            : base(message)
        {
        }
        public NegativeAmountException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
