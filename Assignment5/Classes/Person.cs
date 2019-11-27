using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Person : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"Id ; {this.Id} , First Name : {this.FirstName} , Last Name: {this.LastName} , Role : {this.GetType().Name}";
        }
    }
}