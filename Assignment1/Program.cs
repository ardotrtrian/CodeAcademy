using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem1
            //Write a function that copies given array of double elements into an array of inte elements:
            double[] doubleArray = new double[] { -2.5, 5.63, 8.95, 15.23, 96.55, 78.11, 36.56, 4.44, 81.12, 66.50, -25.33 };

            Array IntArray = Copy(doubleArray);

            foreach (var element in IntArray)
            {
                Console.Write($"{element} ");
            }
        }
        public static Array Copy(double[] doubleArray)
        {
            int size = doubleArray.Length;

            int[] intArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                intArray[i] = Convert.ToInt32(doubleArray[i]);
            }

            return intArray;
        }

    }
}

