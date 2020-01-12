using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmnet9TEST
{
    class Program
    {
        public static BoardingPass CreateBoardingPass(Ticket ticket, double Threshold)
        {
            var BoardingPass1 = new BoardingPass()
            {
                DepartureAirport = ticket.DepartureAirport,
                ArrivalAirport = ticket.ArrivalAirport,
                FlightNumber = ticket.FlightNumber,
                ArrivalTime = ticket.ArrivalTime,
                DepartureTime = ticket.DepartureTime,
                FlightDuration = Extension.Extension.FlightDuration(ticket).TotalMinutes,
                //BonusPoints = (get users all bonus points from previous flights but for simplicity let's say he has total of 900 bonus points),
                BonusPoints = 900,
                SeatArea = SeatArea.Economy
            };
            if (BoardingPass1.BonusPoints > Threshold)
            {
                BoardingPass1.SeatArea = SeatArea.Business;
            }

            return BoardingPass1;
        }

        public static void PrintDetails(ITicket Pass)
        {
            Console.WriteLine($"Passenger Name : { Pass.PassengerName} ," +
                $" LastName : { Pass.PassengerLastName} ," +
                $" FlightNumber : {Pass.FlightNumber} ," +
                $" DepartureAirport : {Pass.DepartureAirport.AirportName} ," +
                $" ArrivalAirport : {Pass.ArrivalAirport.AirportName}"); 
        }
       

        static void Main(string[] args)
        {
            var airport1 = new Airport()
            {
                Id = 1,
                AirportName = "Zvartnots",
                City = "Yerevan",
                BonusPoints = 1000
            };

            var airport2 = new Airport()
            {
                Id = 2,
                AirportName = "Damascus International",
                City = "Damascus",
                BonusPoints = 800
            };

            var ticket1 = new Ticket()
            {
                Id = 1,
                PassengerName = "Ardavazt",
                PassengerLastName = "Trtrian",
                PassengerMiddleName = "Ashod",
                PassportNumber = "10000134AW301",
                DepartureAirport = airport1,
                DepartureTime = new DateTime(2020, 02, 01, 16, 15, 0),
                ArrivalAirport = airport2,
                ArrivalTime = new DateTime(2020, 02, 01, 18, 45, 0),
                FlightNumber = "LK564",
                Price = 285.00,
                PassengerCompany = "ACA",
                BonusPoints = 300
            };
            var ticket2 = new Ticket()
            {
                Id = 1,
                PassengerName = "Hagop",
                PassengerLastName = "Trtrian",
                PassengerMiddleName = "Ashod",
                PassportNumber = "10400134AW301",
                DepartureAirport = airport1,
                DepartureTime = new DateTime(2020, 02, 01, 16, 15, 0),
                ArrivalAirport = airport2,
                ArrivalTime = new DateTime(2020, 02, 01, 18, 45, 0),
                FlightNumber = "LK564",
                Price = 285.00,
                PassengerCompany = "ACA",
                BonusPoints = 550
            };

            List<Ticket> tickets = new List<Ticket>();
            tickets.Add(ticket1);
            tickets.Add(ticket2);

            int MaxOfAllBonuses = tickets.Sum(t => t.BonusPoints);

            double Threshold = ticket1.BonusPoints + (25 * (tickets.Max(t => t.BonusPoints) - tickets.Average(t => t.BonusPoints)))/ 100;

            var BoardingPass = CreateBoardingPass(ticket1, Threshold);

            PrintDetails(ticket1);
        }
    }
}
