using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    class Program
    {
        //Implement the following extension methods:
        //Select, Where, GroupBy, ToList, OrderBy, ToDictionary..
        static void Main(string[] args)
        {
            List<int> book = new List<int>(5) { 1, 2, 3, 4, 5 };
            var books = book.MyWhere(b => b > 3);

            foreach (var item in books)
            {
                Console.WriteLine(item);
            }
        }
    }
}
