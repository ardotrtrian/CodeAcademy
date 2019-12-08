using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Bank_Exception_Classes
{
    class LargeWithdrawAmountException : BankAccountException
    {
        public override string Message
        {
            get
            {
                return "Withdraw amount is larger than balance!";
            }
        }
        public LargeWithdrawAmountException()
            : base()
        {
        }
        public LargeWithdrawAmountException(string message)
            : base(message)
        {
        }
        public LargeWithdrawAmountException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
