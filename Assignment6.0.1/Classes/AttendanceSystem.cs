using Assignment6._0._1.Extension_Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6._0._1
{
    class AttendanceSystem
    {
        public event Action BanAlarmEventHandler;

        public event Action<string> WelcomeEventHandler;

        private readonly HashSet<Users> Users = new HashSet<Users>()
        {
            new Users() { Id=1000, FirstName="Jack", LastName="Sparrow", Status = Status.Banned },
            new Users() { Id=1001, FirstName="George", LastName="Clooney", Status = Status.Active},
            new Users() { Id=1002, FirstName="Steven", LastName="Spielberg", Status = Status.Banned},
            new Users() { Id=1003, FirstName="Matthew", LastName="Mcconaughey", Status = Status.Active},
            new Users() { Id=1004, FirstName="Will", LastName="Smith", Status = Status.Active},
            new Users() { Id=1005, FirstName="Emma", LastName="Stone", Status = Status.Active},
            new Users() { Id=1006, FirstName="Christopher", LastName="Nolan", Status = Status.Active},
            new Users() { Id=1007, FirstName="Quentin", LastName="Tarrentino", Status = Status.Active},
            new Users() { Id=1008, FirstName="Mark", LastName="Whalberg", Status = Status.Active},
            new Users() { Id=1009, FirstName="Ben", LastName="Affleck", Status = Status.Active},
        };

        public void CheckAttendance()
        {
            Console.WriteLine("Please enter First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter LastName: ");
            string lastName = Console.ReadLine();

            var user = Users.
                         Where(u => u.FirstName == firstName.FirstToUpper() && u.LastName == lastName.FirstToUpper()).
                         SingleOrDefault();

            if (user == null)
            {
                throw new Exception("User not found! Please Try Again!");
            }
            switch (user.Status)
            {
                case Status.Active:
                    WelcomeEventHandler?.Invoke(user.FirstName);
                    break;
                case Status.Banned:
                    BanAlarmEventHandler?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }
}
