using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10._2
{
    public static class Primes
    {
        public static List<long> RemoveNonPrimes(List<int> collection)
        {
            List<long> Result = new List<long>();

            bool isPrime = true;

            Parallel.ForEach(collection, element =>
            {
                Parallel.For(2, (int)Math.Sqrt(element)+1, (int n, ParallelLoopState state) =>
                {
                    if (element % n == 0)
                    {
                        isPrime = false;
                        state.Break();
                    }
                });
                if (isPrime)
                {
                    Result.Add(element);
                }
                isPrime = true;
            });
            return Result;
        }
    }
}
