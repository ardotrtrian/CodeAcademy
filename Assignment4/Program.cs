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
            Multimap is a generalization of a map or associative array data type in which
            more than one value may be associate with and returned for a given key[Wiki].
            Create a generic multimap – a data structure which holds multiple values at a key.
            This means we can add multiple values for a single key in a dictionary.
            The implemented type should implement IDictionary interface (generic one
            defined in System.Collections.Generic namespace), i.e. all methods defined in the
            interface should be implemented.
         */
        static void Main(string[] args)
        {
            Multimap<int, char> multimap = new Multimap<int, char>();

            multimap.Add(1, new List<char>() { 'A', 'Z', 'R' });
            multimap.Add(2, new List<char>() { 'V', 'C' });
            multimap.Add(3, new List<char>() { 'X', 'T', 'I' });
            multimap.Add(4, new List<char>() { 'O', 'P', 'W', 'Q' });
            multimap.Add(5, new List<char>() { 'J', 'K', 'H' });
            multimap.Add(6, new List<char>() { 'L', 'T', 'M' });
            multimap.Add(7, new List<char>() { 'D', 'F', 'N' });

            //var list = multimap[10];

            var res = multimap.ContainsKey(3);

            multimap.Remove(6);

            List<char> resultt = new List<char>();
            multimap.TryGetValue(1, out resultt);

            KeyValuePair<int, List<char>>[] result = new KeyValuePair<int, List<char>>[7];

            multimap.CopyTo(result, 0);

            foreach (var item in multimap)
            {
                Console.Write($"Key: {item.Key} , Value: ");
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.Write($"{ item.Value[i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
