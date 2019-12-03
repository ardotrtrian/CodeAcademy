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
            int countOfTwoFours = 0;  //number of 4 tosses occured
            int dieToss = 1;       //to keep track of die tossing process

            //To save the previous 5 tosses
            List<int> FiveRollsValues = new List<int>();

            for (int i = 0; i < RollsCount; i++)
            {
                Console.Write($"Toss number {dieToss++}");

                currentRoll = rand.Next(1,7);

                //if the previous toss value is 4 and equal to current toss value
                if (previousRoll == 4 && currentRoll == 4 )    
                {
                    countOfTwoFours++;
                    TwoFoursEventHandler.Invoke(countOfTwoFours);   //invoke the event 
                }

                //add the curretn toss value to the list
                FiveRollsValues.Add(currentRoll);   

                //if the list already contains five tosses 
                if (FiveRollsValues.Count == 5)
                {
                    //and sum is equal to 20 or more 
                    if (FiveRollsValues.Sum() >= 20)
                    {
                        FiveTossesSumEventHandler.Invoke(FiveRollsValues);  //invoke the event 
                    }

                    //once the event invoking process is over , remove the toss value that occured 5 tosses earlier
                    FiveRollsValues.RemoveAt(0);
                }

                //now the curretn toss value becomes the previous toss value
                previousRoll = currentRoll;

                Console.WriteLine();
            }

        }
    }
}
