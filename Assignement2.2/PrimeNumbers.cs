using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement2._2
{
    class PrimeNumbers : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var p = new PrimeNumbersEnumerator();
            return p;
        }
    }

    class PrimeNumbersEnumerator : IEnumerator
    {
        private int currentPrimeNumber = 1;
        public object Current
        {
            get
            {
                return currentPrimeNumber;
            }
        }
        public bool MoveNext()
        {
            bool primefound = true;

            while (primefound)
            {
                currentPrimeNumber++;

                if (currentPrimeNumber == 2)
                {
                    return true;
                }

                int i;

                for (i = 2; i < currentPrimeNumber / 2 + 1; i++)
                {
                    if (currentPrimeNumber % i == 0)
                    {
                        currentPrimeNumber++;
                        i = 2;
                    }
                }

                if(i== currentPrimeNumber / 2 + 1)
                {
                    return true;
                }
            }

            return primefound;
        }
        public void Reset()
        {
            currentPrimeNumber = 1;
        }
    }
}
