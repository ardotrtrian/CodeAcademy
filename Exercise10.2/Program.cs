using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 2, 4, 5, 10, 11, 12, 13 };

            var newList = Primes.RemoveNonPrimes(list);

            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
