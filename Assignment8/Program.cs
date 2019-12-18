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
            //Where
            List<int> nums = new List<int>(5) { 1, 2, 3, 4, 5 };
            var books = nums.MyWhere(b => b > 3);

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var Books = new List<Book>
            {
                new Book { Id = 2, Name = "Book1", Genre = "Fiction" },
                new Book { Id = 4, Name = "Book2", Genre = "Fiction" },
                new Book { Id = 1, Name = "Book3", Genre = "Comedy" },
                new Book { Id = 3, Name = "Book4", Genre = "Comedy" }
            };

            //Select
            var bookNames = Books.MySelect(b => new { b.Name });

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

            //ToList
            var numList = nums.MyToList();
            foreach (var num in numList)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine();

            //ToDictionary
            var bookDictionaryById = Books.MyToDictionary(b => b.Id);
            foreach (var book in bookDictionaryById)
            {
                Console.WriteLine($"{book.Key} : {book.Value.Name}");
            }
            Console.WriteLine();

            //where and toList
            var numsList = nums.MyWhere(n => n > 2).MyToList();

            //GroupBy
            var GroupedBooks = Books.MyGroupBy(b => b.Genre);
            foreach (var group in GroupedBooks)
            {
                Console.WriteLine($"{group.Key} : ");
                foreach (var book in group)
                {
                    Console.WriteLine(book.Id);
                }
            }
        }
    }
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
    }
}
