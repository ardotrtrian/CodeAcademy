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
            List<int> nums = new List<int>(5) { 1, 2, 3, 4, 5 };
            var books = nums.MyWhere(b => b > 3);

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            List<Book> Books = new List<Book>();

            Books.Add(new Book { Id = 1, Name = "Book1" });
            Books.Add(new Book { Id = 2, Name = "Book2" });
            Books.Add(new Book { Id = 3, Name = "Book3" });
            Books.Add(new Book { Id = 4, Name = "Book4" });

            var bookNames = Books.MySelect(b => new { b.Name});

            foreach (var b in bookNames)
            {
                Console.WriteLine(b.Name);
            }
            Console.WriteLine();

            var Ids = Books.MySelect(b => b.Id);

            foreach (var id in Ids)
            {
                Console.WriteLine(id);
            }
            Console.WriteLine();
            var numList = nums.MyToList();
            foreach (var num in numList)
            {
                Console.WriteLine(num);
            }
        }
    }
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
