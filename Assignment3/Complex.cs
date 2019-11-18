using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    struct Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double img)
        {
            Real = real;
            Imaginary = img;
        }
        //(a + ib) + (c + id) = (a + c) + (b + d)i
        public static Complex Addition(Complex left , Complex right)
        {
            return new Complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }
        //(a + ib) - (c + id) = (a - c) + (b - d)i
        public static Complex Subtraction(Complex left, Complex right)
        {
            return new Complex(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }
        //(a + ib) * (c + id) = (ac - bd) + (ad + cb)i
        public  static Complex Multiplication(Complex left,Complex right)
        {
            return new Complex((left.Real * right.Real - left.Imaginary * right.Imaginary), (left.Real * right.Imaginary + left.Imaginary * right.Real));
        }
        //(a + bi) / (c + di) = (a + bi) / (c + di) * (c - di) / (c - di) = (a + bi) * (c - di) / (c^2 + d^2)
        public static Complex Devision(Complex left ,Complex right)
        {
            // Smith's formula.
            double a = left.Real;
            double b = left.Imaginary;
            double c = right.Real;
            double d = right.Imaginary;

            if (Math.Abs(d) < Math.Abs(c))
            {
                double doc = d / c;
                return new Complex((a + b * doc) / (c + d * doc), (b - a * doc) / (c + d * doc));
            }
            else
            {
                double cod = c / d;
                return new Complex((b + a * cod) / (d + c * cod), (-a + b * cod) / (d + c * cod));
            }
        }
        // |a+bi|=sqrt(a^2 + b^2)
        public static double Magnitude(Complex complexNumber)
        {
            return Math.Sqrt(complexNumber.Real* complexNumber.Real + complexNumber.Imaginary* complexNumber.Imaginary);
        }
        public static double Phase(Complex complexNumber)
        {
            return Math.Atan2(complexNumber.Imaginary, complexNumber.Real);
        }
        public override string ToString()
        {
            return $"{Real} + {Imaginary}i ";
        }
    }
}
