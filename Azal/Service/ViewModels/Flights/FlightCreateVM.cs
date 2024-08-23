using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Flights
{
    public class FlightCreateVM
    {
        public string FlightNumber { get; set; }
        public int TicketCount { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int ArrivalAirport { get; set; }
        public int DepartureAirport { get; set; }
        public int Plane { get; set; }
        public int Price_econom { get; set; }
        public int Price_biznes { get; set; }
        public int PassengerCount { get; set; }

    }
}
