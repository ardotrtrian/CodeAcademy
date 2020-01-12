using System;

namespace Assignmnet9TEST
{
    public interface ITicket
    {
        int Id { get; set; }
        string PassengerName { get; set; }
        string PassengerLastName { get; set; }
        string PassengerMiddleName { get; set; }
        string PassportNumber { get; set; }
        string FlightNumber { get; set; }
        Airport DepartureAirport { get; set; }
        Airport ArrivalAirport { get; set; }
        DateTime DepartureTime { get; set; }
        DateTime ArrivalTime { get; set; }
        int BonusPoints { get; set; }
        string PassengerCompany { get; set; }
        double Price { get; set; }
    }
}