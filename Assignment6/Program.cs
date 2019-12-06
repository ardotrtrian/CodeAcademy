using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            Die die = new Die();     //publisher

            DieTossingValues dieTossingValues = new DieTossingValues();      //subscriber

            die.TwoFoursEventHandler += dieTossingValues.OnTwoFoursCount;

            die.FiveTossesSumEventHandler += dieTossingValues.OnSumIsGreaterThanTwenty;

            die.DieExperimentFinished += dieTossingValues.OnDieExperimentFinished;

            die.Roll(100);
        }
    }

}
