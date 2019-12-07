using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6._0._1
{
    class GreetingEvents
    {
        public void OnWelcome(string FirstName)
        {
            Console.WriteLine($"Welcome {FirstName}!. Have a nice day! :) ");
        }
        public void OnBanAlarm()
        {
            Console.WriteLine("Sorry! You are banned from entering!");
        }
    }
}
