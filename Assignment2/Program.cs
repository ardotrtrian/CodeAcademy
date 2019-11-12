using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows of matrix 'A'");
            int numberOFRowsA = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of columns of matrix 'A'");
            int numberOfColumnsA = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of rows of matrix 'B'");
            int numberOFRowsB = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of columns of matrix 'B'");
            int numberOfColumnsB = int.Parse(Console.ReadLine());

            Matrix matrixA = new Matrix(numberOFRowsA, numberOfColumnsA);
            Matrix matrixB = new Matrix(numberOFRowsB, numberOfColumnsB);

            Console.WriteLine("Matrix A:");
            for (int i = 0; i < numberOFRowsA; i++)
            {
                for (int j = 0; j < numberOfColumnsA; j++)
                {
                    Console.Write($"{matrixA[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nMatrix B:");
            for (int i = 0; i < numberOFRowsB; i++)
            {
                for (int j = 0; j < numberOfColumnsB; j++)
                {
                    Console.Write($"{matrixB[i, j]} ");
                }
                Console.WriteLine();
            }

            //Multiplication
            var resmult = Matrix.Multiplication(matrixA, matrixB);
            Console.WriteLine("\nMultiplying matrix A and B gives: ");
            for (int i = 0; i < resmult.NumberOfRows; i++)
            {
                for (int j = 0; j < resmult.NumberOfColumns; j++)
                {
                    Console.Write($"{resmult[i, j]} ");
                }
                Console.WriteLine();
            }

            //Scalar Multiplication
            Console.WriteLine("\nEnter a constant integer you want to multiply Matrix A with");
            int constant = int.Parse(Console.ReadLine());
            var resScMult = Matrix.ScalarMultiplication(matrixA, constant);
            Console.WriteLine("\nScalar Multiplication of matrix A gives: ");
            for (int i = 0; i < resScMult.NumberOfRows; i++)
            {
                for (int j = 0; j < resScMult.NumberOfColumns; j++)
                {
                    Console.Write($"{resScMult[i, j]} ");
                }
                Console.WriteLine();
            }

            //Transpose Matrix
            var trans = Matrix.Transpose(matrixA);
            Console.WriteLine("\nTranspose of matrix A is: ");
            for (int i = 0; i < trans.NumberOfRows; i++)
            {
                for (int j = 0; j < trans.NumberOfColumns; j++)
                {
                    Console.Write($"{trans[i, j]} ");
                }
                Console.WriteLine();
            }

            //Addition
            var resAdd = Matrix.Addition(matrixA, matrixB);
            Console.WriteLine("\nAdding matrix A and B gives: ");
            for (int i = 0; i < resAdd.NumberOfRows; i++)
            {
                for (int j = 0; j < resAdd.NumberOfColumns; j++)
                {
                    Console.Write($"{resAdd[i, j]} ");
                }
                Console.WriteLine();
            }

            //Maximum element
            double max = Matrix.Maximum(matrixA);
            Console.WriteLine($"\nMaximum element in matrix A is {max}");

            //Minimum element
            double min = Matrix.Minimum(matrixA);
            Console.WriteLine($"\nMinimum element in matrix A is {min}\n");

            //Is matrix orthogonal or no.
            bool orthogonal = Matrix.IsOrthogonal(matrixA);
            string message = orthogonal ? "Matrix A is orthogonal" : "Matrix A is not orthgonal";

            Console.WriteLine(message);

            //get determinant of matrix
            var det = Matrix.DeterminantOfMatrix(matrixA, 3);
            Console.WriteLine($"Determinant of matrix is {det}");

            //Inverse of matrix A
            Console.WriteLine("\nInverse of matrix A is: ");
            Matrix inverse = Matrix.Inverse(matrixA);
            for (int i = 0; i < inverse.NumberOfRows; i++)
            {
                for (int j = 0; j < inverse.NumberOfColumns; j++)
                {
                    Console.Write($"{inverse[i, j]} ");
                }
                Console.WriteLine();
            }

            
        }
    }
}
