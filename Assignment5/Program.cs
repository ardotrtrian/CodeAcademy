using Assignment5.Classes;
using Assignment5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /*
    
    Create the following class hierarchy:
    • Person - general class for anyone, which has id, first name and last name.
    o Employee - general class for all employees, holding the field salary and department. 
    The department can only have one of the following values: Production, Accounting, Sales or Marketing.
    ▪ Manager – holds a set of employees under his/her command.
    ▪ RegularEmployee
    • SalesEmployee – holds a set of sales. A sale hold product name, date
    and price.
    • Developer - holds a set of projects. A project holds project name,
    project start date, details and a project state (open or closed).
    o Customer – hold the net purchase amount (total amount of money the customer has spent).

    Extract interfaces for each class (IPerson, IEmployee, IManager, etc.) The interfaces should hold their
    public properties and methods. Each class (Person, Employee, Manager, etc.) should implement its respective interface.

    Avoid code duplication through abstraction; encapsulate all data.
    Override ToString() in all classes to print details information about the object.
    Create several employees of type Manager, SalesEmployee and Developer and add them into a single collection and print them. 
     
    */
    class Program
    {
        static void Main(string[] args)
        {
            //Projects
            IProject Project1 = new Project() 
            {
                Name = "Bank System" , 
                StartDate = DateTime.Today , 
                Details = "https://study.com/academy/lesson/banking-system-definition-types.html",
                IsOpen = true 
            };
            IProject Project2 = new Project()
            {
                Name = "Flappy Bird Game",
                StartDate = new DateTime(2019, 04, 01),
                Details = "https://flappybird.io/",
                IsOpen = false
            };

            //Developer
            IRegularEmployee developer1 = new Developer()
            {
                Id = 1246,
                FirstName = "Jack",
                LastName = "Smith",
                Salary = 450000,
                Department = Enums.Department.Production,
                Projects = new HashSet<IProject>()
                {
                    Project1,Project2
                }
            };

            //Sales
            ISales product1 = new Sales()
            {
                ProductName = "Invoices",
                Date = new DateTime(2018,01,24),
                Price = 8000000
            };

            //Sales Employee
            IRegularEmployee salesEmployee = new SalesEmployee()
            {
                Id = 3780,
                FirstName = "Mary",
                LastName = "Jane",
                Department = Enums.Department.Accounting,
                Salary = 250000,
                Sales = new HashSet<ISales>()
                {
                    product1
                }
            };

            //Manager
            IManager manager = new Manager()
            {
                Id = 1001,
                FirstName = "Bruce",
                LastName = "Wayne",
                Department = Enums.Department.Marketing,
                Salary = 1200000,
                ManagerOf = new HashSet<IEmployee>()
                {
                    developer1,
                    salesEmployee
                }
            };

            //List Of employees
            List<IEmployee> EmployeesList = new List<IEmployee>();
            EmployeesList.Add(developer1);
            EmployeesList.Add(salesEmployee);
            EmployeesList.Add(manager);

            foreach (IEmployee employee in EmployeesList)
            {
                Console.WriteLine(employee.ToString());
            }

        }
    }
}
