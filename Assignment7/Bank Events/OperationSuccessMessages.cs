using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Bank_Events
{
    class OperationSuccessMessages
    {
        public void OnWithdrawSuccess(double balance)
        {
            Console.WriteLine($"Withdraw is successfully done! Your current Balance is {balance}");
        }
        public void OnDepositSuccess(double balance)
        {
            Console.WriteLine($"Deposit is successfully done! Your new balance is {balance}");
        }
    }
}
