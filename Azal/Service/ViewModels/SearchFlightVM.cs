using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class SearchFlightVM
    {
        
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepatureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Count { get; set; }
        public string TicketType { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
    }
}
