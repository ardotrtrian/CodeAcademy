using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9
{
    public struct Time
    {
        public int TimeOfDayAsMinutes { get; private set; }
        public int Minutes { get; private set; }
        public int Hours { get; private set; }
        public static Time Noon
        {
            get
            {
                return new Time(12, 0);
            }
        }

        public Time(int hours, int minutes)
        {
            if (hours > 23 || hours < 0)
            {
                throw new Exception("Wrong hours Format");
            }
            this.Hours = hours;
            if (minutes > 59 || minutes < 0)
            {
                throw new Exception("Wrong minutes format");
            }
            this.Minutes = minutes;

            this.TimeOfDayAsMinutes = (Hours * 60) + Minutes;
        }

        public static Time operator +(Time left, Time right)
        {
            
            if (left.Minutes > 59 || left.Minutes < 0 || right.Minutes > 59 || right.Minutes < 0)
            {
                throw new Exception("Wrong minutes format");
            }
            if (left.Hours > 23 || left.Hours < 0 || right.Hours > 23 || right.Hours < 0)
            {
                throw new Exception("Wrong hours Format");
            }
            if (left.Hours + right.Hours > 23)
            {
                throw new Exception("Hours can not exceed 23");
            }

            var resultTime = new Time()
            {

                Hours = left.Hours + right.Hours,
                Minutes = left.Minutes + right.Minutes,
                TimeOfDayAsMinutes = left.TimeOfDayAsMinutes + right.TimeOfDayAsMinutes
            };

            
            if (resultTime.Minutes >= 60)
            {
                resultTime.Hours++;
                resultTime.Minutes -= 60;
            }
            return resultTime;
        }

        public static Time operator -(Time left, Time right)
        {
            if (left.Minutes > 59 || left.Minutes < 0 || right.Minutes > 59 || right.Minutes < 0)
            {
                throw new Exception("Wrong minutes format");
            }
            if (left.Hours > 23 || left.Hours < 0 || right.Hours > 23 || right.Hours < 0)
            {
                throw new Exception("Wrong hours Format");
            }

            var resultTime = new Time()
            {
                Minutes = Math.Abs(left.Minutes - right.Minutes),
                Hours = Math.Abs(left.Hours - right.Hours),
                TimeOfDayAsMinutes = left.TimeOfDayAsMinutes - right.TimeOfDayAsMinutes
            };

            if (resultTime.Minutes >= 60)
            {
                resultTime.Hours++;
                resultTime.Minutes -= 60;
            }
            return resultTime;
        }

        public static implicit operator Time(int minutes)
        {
            if (minutes > 1439 || minutes < 0)
            {
                throw new Exception("Minutes are out of 23 hours and 59 minutes boundaries");
            }
            if (true)
            {

            }
            var resHours = minutes / 60;
            var resMinutes = minutes % 60;

            return new Time(resHours, resMinutes);
        }

        public static explicit operator int(Time time)
        {
            return (time.Hours * 60) + time.Minutes;
        }

        public override string ToString()
        {
            return $"{this.Hours.ToString("D2")} : {this.Minutes.ToString("D2")}";
        }
    }
}
