using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time = new Time(13, 30);
            Time time2 = new Time(23,35);

            //Console.WriteLine($"{time.TimeOfDayAsMinutes} minutes");
            //var str = time.ToString();
            //Console.WriteLine(str);

            //Console.WriteLine(time.Noon.TimeOfDayAsMinutes.ToString());

            Time resTime = time + time2;
            Console.WriteLine(resTime.ToString());

            Time resTime2 = time - time2;
            Console.WriteLine(resTime2.ToString());

            Time time3 = (Time)110;

            int minutes = (int)time3;
        }
    }
}
