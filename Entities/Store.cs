using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Entities
{
    public class Store
    {
        [DataMember]
        public static List<Book> Books { get; set; }

        static Store()
        {
            Books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Author = "Marcel Proust",
                    Title = "In Search Of Lost Times",
                    Price = 19.59,
                    Year = 1913
                },
                new Book
                {
                    Id = 2,
                    Author = "James Joyce",
                    Title = "Ulysses",
                    Price = 15.99,
                    Year = 1904
                }
            };
        }
    }
}
