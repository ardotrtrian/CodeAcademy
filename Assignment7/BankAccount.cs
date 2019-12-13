using Assignment7.Bank_Exception_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class BankAccount
    {
        public double Balance { get; set; }

        private double _InterestRate;
        public double InterestRate
        {
            get
            {
                return this._InterestRate;
            }
            set
            {
                if (value < 0.0 || value > 22.0 )
                {
                    throw new InvalidInterestRateException();
                }

                this._InterestRate = value;
            }
        }

        public event Action<double> WithdrawSuccessEventHandler;
        public event Action<double> DepositSuccessEventHandler;

        public BankAccount(double balance, double interestRate)
        {
            Balance = balance;
            InterestRate = interestRate;
        }

        public void Withdraw(double amount)
        {
            try
            {
                if (amount > Balance)
                {
                    throw new LargeWithdrawAmountException();
                }
                if (amount < 0)
                {
                    throw new NegativeAmountException();
                }

                Balance -= amount;

                WithdrawSuccessEventHandler?.Invoke(this.Balance);
            }
            catch (LargeWithdrawAmountException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"-- Your balance is {this.Balance} --");
            }
            catch (NegativeAmountException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"-- Your balance is {this.Balance} --");
            }

        }
        public void Deposit(double amount)
        {
            try
            {
                if (amount < 0)
                {
                    throw new NegativeAmountException();
                }
                Balance += amount;

                DepositSuccessEventHandler?.Invoke(this.Balance);
            }
            catch(NegativeAmountException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"-- Your balance is {this.Balance} --");
            }
        }
    }
}
