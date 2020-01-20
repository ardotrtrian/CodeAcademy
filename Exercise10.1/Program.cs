using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Alarm alarm = new Alarm();
            alarm.SetAlarm(DateTime.Now.AddSeconds(4));
        }
    }
}
