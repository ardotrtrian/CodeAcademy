using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        /* 1.
         *  Multimap is a generalization of a map or associative array data type in which
            more than one value may be associate with and returned for a given key[Wiki].
            Create a generic multimap – a data structure which holds multiple values at a key.
            This means we can add multiple values for a single key in a dictionary.
            The implemented type should implement IDictionary interface (generic one
            defined in System.Collections.Generic namespace), i.e. all methods defined in the
            interface should be implemented.
         */

        static void Main(string[] args)
        {
            Multimap<int, int> multimap = new Multimap<int, int>();

            multimap.Add(2,new List<int>() { 1,2,3,4});
            multimap.Add(3, new List<int>() { 3,4});
            multimap.Add(1, new List<int>() { 1});

            var list = multimap[2];

            KeyValuePair<int,List<int>>[] result = new KeyValuePair<int, List<int>>[3];

            multimap.CopyTo(result, 0);
        }
    }
}
