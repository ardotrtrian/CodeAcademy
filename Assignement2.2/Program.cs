using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an Enumertar function Power() that returns all powers of number from 1 to its exponent

            int number = 3;
            int exponent = 6;

            Console.WriteLine($"All powers of {number} to {exponent} are:");

            foreach (var item in Power(number, exponent))
            {
                Console.Write($"{item} ");
            }

            //---------------------------------------------------------------------------------------------

            //Create a class primeNumbers that enumerates all prime numbers.

            PrimeNumbers primeNumbers = new PrimeNumbers();

            IEnumerator enumerator = primeNumbers.GetEnumerator();

            Console.WriteLine($"\nPrime numbers until 100 are:");
            
            while(enumerator.MoveNext())
            {
                if ((int)enumerator.Current > 100)
                {
                    break;
                }
                Console.Write($"{enumerator.Current} ");
            }

            //-------------------------------------------------------------------------------------------

            //Implement a class BinaryTree and an enumerator doing a prefix traversal.

            //TODO

        }
        static IEnumerable Power(int number, int exponent)
        {
            int index = 0;
            int PreviousResult = 1;
            while(exponent > index++)
            {
                PreviousResult = number * PreviousResult;
                yield return PreviousResult;
            }
        }
    }
}
