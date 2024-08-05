using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Flights
{
    public class FlightEditVM
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public int TicketCount { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int ArrivalAirport { get; set; }
        public int DepartureAirport { get; set; }
        public int Plane { get; set; }
        public int Price_azn { get; set; }
        public int Price_usd { get; set; }
        public int PassengerCount { get; set; }
    }
}
