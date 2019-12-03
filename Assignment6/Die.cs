using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Die
    {
        public delegate void TwoFoursInRowDelegate(int count);

        public delegate void FiveTossesSum(List<int> Tosses);

        public event TwoFoursInRowDelegate TwoFoursEventHandler;

        public event FiveTossesSum FiveTossesSumEventHandler; 

        public void Roll(int RollsCount)
        {
            Random rand = new Random();

            int previousRoll = 0;
            int currentRoll;
            int countOfTwoFours = 0;
            int dieToss = 1;

            List<int> FiveRollsValues = new List<int>();

            for (int i = 0; i < RollsCount; i++)
            {
                Console.Write($"Toss number {dieToss++}");

                currentRoll = rand.Next(1,7);

                if (previousRoll == 4 && currentRoll == 4 )
                {
                    countOfTwoFours++;
                    TwoFoursEventHandler.Invoke(countOfTwoFours);
                }

                FiveRollsValues.Add(currentRoll);

                if (FiveRollsValues.Count == 5)
                {
                    if (FiveRollsValues.Sum() >= 20)
                    {
                        FiveTossesSumEventHandler.Invoke(FiveRollsValues);
                    }
                    FiveRollsValues.RemoveAt(0);
                }
                previousRoll = currentRoll;

                Console.WriteLine();
            }

        }
    }
}
