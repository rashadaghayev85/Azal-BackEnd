using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Flights
{
    public class FlightDetailVM
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public int TicketCount { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Price_azn { get; set; }
        public int Price_usd { get; set; }
        public int PassengerCount { get; set; }
    }
}
