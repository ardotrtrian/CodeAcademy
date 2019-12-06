using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Die
    {
        public delegate void TwoFoursInRowDelegate(object source, int count);

        public delegate void FiveTossesSum(object source, List<int> Tosses);

        //--
        public event TwoFoursInRowDelegate TwoFoursEventHandler;
        // Or use this instead of a backing delegate :: 
        //public event EventHandler<int> TwoFoursEventHandler;
        //--

        public event FiveTossesSum FiveTossesSumEventHandler;

        //EventHandler without using a backing delegate
        public event Action DieExperimentFinished; 

        public void Roll(int RollsCount)
        {
            Random rand = new Random();

            int previousRoll = 0;  
            int currentRoll;
            int countOfTwoFours = 0;   //number of 4 tosses occured
            int dieToss = 1;           //to keep track of die tossing process

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
                    TwoFoursEventHandler?.Invoke(this, countOfTwoFours);   //raise the event 
                }

                //add the current toss value to the list
                FiveRollsValues.Add(currentRoll);   

                //if the list already contains five tosses 
                if (FiveRollsValues.Count == 5)
                {
                    //and sum is equal to 20 or more 
                    if (FiveRollsValues.Sum() >= 20)
                    {
                        FiveTossesSumEventHandler?.Invoke(this, FiveRollsValues);  //raise the event 
                    }

                    //once the event invoking process is over , remove the toss value that occured 5 tosses earlier
                    FiveRollsValues.RemoveAt(0);
                }

                //now the current toss value becomes the previous toss value
                previousRoll = currentRoll;

                Console.WriteLine();
            }
            //Once the experiment is over, we raise this event
            DieExperimentFinished?.Invoke();
        }
    }
}
