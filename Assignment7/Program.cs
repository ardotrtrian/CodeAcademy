using Assignment7.Bank_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    /*
     BankAccount:
     Implement a class which represents a bank account with Balance and InterestRate properties,
     and has the following methods defined:
     Withdraw(double amount)for removing specified amount of money from the account;
     and Deposit(double amount)for adding specified amount of money to the account.
     Interest rate of the account must be between 0.0 to 22.0. An exception must be thrown
     when a bank account is defined with illegal interest rate.
     User should get exception when:
     •Attempts to withdraw or deposit a negative amount
     •Attempts to withdraw an amount larger than the current balance
    */

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account101 = new BankAccount(230_500.50, 5.7);
            OperationSuccessMessages messages = new OperationSuccessMessages();     //event subscriber

            account101.DepositSuccessEventHandler += messages.OnDepositSuccess;
            account101.WithdrawSuccessEventHandler += messages.OnWithdrawSuccess;

            account101.Withdraw(100_000);
            account101.Deposit(40_000);
            account101.Deposit(-40_000);


        }
    }
}