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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookStoreService" in both code and config file together.
    [ServiceContract]
    public interface IBookStoreService : IDisposable
    {
        [OperationContract]
        IEnumerable<Book> GetAllBooks();

        [OperationContract]
        void AddNewBook(Book book);

        [OperationContract]
        void UpdateBookPriceById(int bookId, double newPrice);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
