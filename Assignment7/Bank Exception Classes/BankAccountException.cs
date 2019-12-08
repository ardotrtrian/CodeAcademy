using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Bank_Exception_Classes
{
    class BankAccountException : Exception
    {
        public override string Message => base.Message;

        public BankAccountException()
            : base()
        {
        }
        public BankAccountException(string message)
            : base(message)
        {
        }
        public BankAccountException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
