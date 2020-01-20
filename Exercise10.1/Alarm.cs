using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise10._1
{
    public class Alarm
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int MilliSecondsToNextAlarm { get; set; }

        System.Timers.Timer AlarmTimer;

        public void SetAlarm(DateTime time)
        {
            this.Hour = time.Hour;
            this.Minute = time.Minute;
            this.MilliSecondsToNextAlarm = (int)(time - DateTime.Now).TotalMilliseconds;

            Console.WriteLine($"The alarm will go off in {(time - DateTime.Now).Hours} hours and {(time - DateTime.Now).Minutes} minutes.");

            AlarmTimer = new System.Timers.Timer(MilliSecondsToNextAlarm);

            AlarmTimer.Elapsed += AlarmTimer_Elapsed;

            AlarmTimer.Enabled = true;

            Console.WriteLine("To cancel Alarm, Press 'Space'.");

            if (Console.ReadKey().KeyChar == ' ')
            {
                AlarmTimer.Enabled = false;
                Console.WriteLine("Alarm is canceled");
            }
        }

        private void AlarmTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Alarm has went off. Press 'Esc' to cancel it.");
            Console.Beep(1000, 10000);
        }
    }
}
