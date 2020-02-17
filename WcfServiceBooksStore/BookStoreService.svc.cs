using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace WcfServiceBooksStore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookStoreService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookStoreService.svc or BookStoreService.svc.cs at the Solution Explorer and start debugging.
    public class BookStoreService : IBookStoreService
    {
        public void AddNewBook(Book book)
        {
            if (book == null)
            {
                throw new Exception("Book is not provided!");
            }

            Store.Books.Add(book);

            Console.WriteLine("Book is successfully added!");
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return Store.Books;
        }

        public void UpdateBookPriceById(int bookId, double newPrice)
        {
            var bookInStore = Store.Books.Find(book => book.Id == bookId);

            if (bookInStore == null)
            {
                throw new Exception("No books found against the ID");
            }

            bookInStore.Price = newPrice;

            Console.WriteLine("Book is successfully updated!");
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void Dispose()
        {

        }
    }
}
