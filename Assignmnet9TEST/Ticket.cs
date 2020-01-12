using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmnet9TEST
{
    public class Ticket : ITicket
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public string PassengerLastName { get; set; }
        public string PassengerMiddleName { get; set; }
        public string PassportNumber { get; set; }
        public string FlightNumber { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int BonusPoints { get; set; }
        public string PassengerCompany { get; set; }
        public double Price { get; set; }
    }
}
