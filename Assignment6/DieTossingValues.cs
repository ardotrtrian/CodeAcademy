﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class DieTossingValues
    {
        public void OnTwoFoursCount(object source, int count)
        {
            Console.Write($" => Two Fours in a row ({count})");
        }

        public void OnSumIsGreaterThanTwenty(object source, List<int> FiveToses)
        {
            Console.Write(" => last 5 tosses values are greater than twenty : ");

            for (int i = 0; i < FiveToses.Count; i++)
            {
                Console.Write(FiveToses[i]);
                Console.Write(" ");
            }
            Console.Write("\n");
        }

        public void OnDieExperimentFinished()
        {
            Console.WriteLine("\n||EXPERIMENT IS FINISHED||\n");
        }
    }
}
