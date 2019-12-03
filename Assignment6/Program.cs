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
            Die die = new Die();

            die.TwoFoursEventHandler += TwoFoursCount;

            die.FiveTossesSumEventHandler += SumIsGreaterThanTenty;

            die.Roll(100);
        }

        static void TwoFoursCount(int count)
        {
            Console.Write($" => Two Fours in a row ({count})");
        }

        static void SumIsGreaterThanTenty(List<int> FiveToses)
        {
            Console.Write(" => last 5 tosses values are greater than twenty : ");

            for (int i = 0; i < FiveToses.Count; i++)
            {
                Console.Write(FiveToses[i]);
                Console.Write(" ");
            }
            Console.Write("\n");
        }
    }
}
