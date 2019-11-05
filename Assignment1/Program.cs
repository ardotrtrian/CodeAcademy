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
            //Problem 1
            //Write a function that copies given array of double elements into an array of inte elements:
            double[] doubleArray = new double[] { -2.5, 5.63, 8.95, 15.23, 96.55, 78.11, 36.56, 4.44, 81.12, 66.50, -25.33 };
            Array IntArray = Copy(doubleArray);
            foreach (var element in IntArray)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();

            //problem 2
            //Write a function to delete an element at desired position from an array. 
            char[] Array2 = new char[] { 'a', 'b', 'g', 't', 'e', 'u', 'i', 'z' };
            Console.WriteLine("Enter the index of element you want to delete");
            int elementToDelete = int.Parse(Console.ReadLine());
            char[] resultArray = RemoveAt(Array2, elementToDelete);
            foreach (var element in resultArray)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();

            //Write a program to print the upper triangular of a given square matrix. Fill the other elements with zeros
            int[,] matrix = new int[4, 4] { { 1, 2, 3, 4 }, { 4, 5, 6, 6 }, { 7, 8, 9, 8 }, { 5, 9, 3, 7 } };
            Print(matrix);
        }
        public static int[] Copy(double[] doubleArray)
        {
            int size = doubleArray.Length;

            int[] intArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                intArray[i] = Convert.ToInt32(doubleArray[i]);
            }

            return intArray;
        }

        public static T[] RemoveAt<T>(T[] source, int index) //works for all types of arrays
        {
            //My approach:
            //Arrays are immutable in nature so I have to create a new array that is one element shorter 
            //and copy the old items to the new array, excluding the element I want to delete.

            if (source == null) //array is empty
            {
                throw new ArgumentNullException("source is null");
            }

            if (index >= source.Length || index<0) //index is out of array length range
            {
                throw new ArgumentOutOfRangeException($"index {index} is outside of bounds of source array");
            }

            int n = source.Length - 1;
            T[] newArray = new T[n];
            int newPointer = 0;  //new array pointer on index
            int sourcePointer = 0;  //source array pointer on index

            foreach (var element in source)
            {
                if (sourcePointer != index) 
                {
                    newArray[newPointer] = source[sourcePointer];
                    newPointer++;
                    sourcePointer++;
                }
                else
                {
                    sourcePointer++;
                }
            }
            return newArray;
        }
        public static void Print<T>(T[,] matrix)
        {
            int n = matrix.Length / matrix.GetLength(0);

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    if (column >= row)
                    {
                        Console.Write($"{matrix[row, column]} ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

