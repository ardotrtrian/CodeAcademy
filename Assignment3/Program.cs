using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex leftComplex = new Complex(3, 4);
            Complex rightComplex = new Complex(6, 8);

            Console.WriteLine("Addition: " + Complex.Addition(leftComplex, rightComplex).ToString());

            Console.WriteLine("Subtraction: " + Complex.Subtraction(leftComplex, rightComplex).ToString());

            Console.WriteLine("Multiplication: " + Complex.Multiplication(leftComplex, rightComplex).ToString());

            Console.WriteLine("Devision: " + Complex.Devision(leftComplex, rightComplex).ToString());

            Console.WriteLine("Magnitude: " + Complex.Magnitude(rightComplex));

            Console.WriteLine("Phase: " + Complex.Phase(leftComplex));
            //Console.WriteLine(complex.ToString());
        }
    }
}
