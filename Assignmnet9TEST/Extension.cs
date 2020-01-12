using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmnet9TEST.Extension
{
    public static class Extension
    {
        public static TimeSpan FlightDuration(this Ticket ticket)
        {
            return ticket.ArrivalTime - ticket.DepartureTime;
        }
    }
}
