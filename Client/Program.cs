using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfServiceBooksStore;
using Entities;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WcfServiceBooksStore.BookStoreService)))
            {
                host.Open();

                Console.WriteLine($"Hosting started at {DateTime.Now.ToString()}");

                using (BookStoreService bookStore = new BookStoreService() )
                {
                    bookStore.AddNewBook(
                        new Book 
                        {
                            Id=3,
                            Author="Miguel de Cervantes",
                            Price=18.49,
                            Title = "Don Quixote",
                            Year=1900 
                        });
                    bookStore.UpdateBookPriceById(3, 20.00);

                    foreach (var book in bookStore.GetAllBooks())
                    {
                        Console.WriteLine($"{book.Title}, {book.Price} ");
                    }
                }
            }
        }
    }
}
