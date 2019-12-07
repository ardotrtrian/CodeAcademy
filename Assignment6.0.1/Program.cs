using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6._0._1
{
    /*
     * Write a program for Online Attendance. 
     * The conditions are as follow:
     * 1.User provides their name as Input and then application show message to 
     * “Welcome [name of the user]”.2.Jack, Steven, and Mathew are banned for the organization. 
     * So, when any user enters Jack, Steven, and Mathew as username, the application raisesan 
     * event and fire alarm.For this task use Action/Func delegates defined in .Net framework.
    */

    class Program
    {
        static void Main(string[] args)
        {
            AttendanceSystem system = new AttendanceSystem();

            GreetingEvents greeting = new GreetingEvents();

            system.WelcomeEventHandler += greeting.OnWelcome;
            system.BanAlarmEventHandler += greeting.OnBanAlarm;

            system.CheckAttendance();
        }
    }
}
