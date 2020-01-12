using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmnet9TEST
{
    class BoardingPass : Ticket
    {
        public string Gate { get; set; }
        public SeatArea SeatArea { get; set; }
        public double FlightDuration { get; set; }
    }
}
