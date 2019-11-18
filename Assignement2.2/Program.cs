using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an Enumertar function Power() that returns all powers of number from 1 to its exponent
            int number = 3;
            int exponent = 6;
            Console.WriteLine($"All powers of {number} to its exponent {exponent} are:");

            foreach (var item in Power(number, exponent))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            //---------------------------------------------------------------------------------------------

            //Create a class primeNumbers that enumerates all prime numbers.

            PrimeNumbers primeNumbers = new PrimeNumbers();

            IEnumerator enumerator = primeNumbers.GetEnumerator();

            Console.WriteLine($"Prime numbers until 100 are:");
            
            while(enumerator.MoveNext())
            {
                if ((int)enumerator.Current > 100)
                {
                    break;
                }

                Console.Write($"{enumerator.Current} ");
            }

            //-------------------------------------------------------------------------------------------
            Console.WriteLine();

            //Implement a class BinaryTree and an enumerator doing a prefix traversal.
            BinaryTree binaryTree = new BinaryTree();
            
            //filling the binary tree with nodes
            binaryTree.Insert(25);
            binaryTree.Insert(20);
            binaryTree.Insert(10);
            binaryTree.Insert(22);
            binaryTree.Insert(5);
            binaryTree.Insert(12);
            binaryTree.Insert(1);
            binaryTree.Insert(8);
            binaryTree.Insert(36);
            binaryTree.Insert(30);
            binaryTree.Insert(40);
            binaryTree.Insert(38);
            binaryTree.Insert(28);
            binaryTree.Insert(48);
            binaryTree.Insert(45);
            binaryTree.Insert(50);
            binaryTree.Insert(15);

            var treeEnumerator = binaryTree.PreOrderTraversal();

            Console.WriteLine("Nodes of the binary tree in a preorder traversal:");
            while (treeEnumerator.MoveNext())
            {
                Console.Write($"{treeEnumerator.Current.ToString()} ");
            }
            Console.WriteLine();
        }

        static IEnumerable Power(int number, int exponent)
        {
            int index = 0;
            int PreviousResult = 1;
            while(exponent > index++)
            {
                PreviousResult = number * PreviousResult;
                yield return PreviousResult;
            }
        }
    }
}
