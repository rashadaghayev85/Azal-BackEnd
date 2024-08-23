using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Flight :BaseEntity
    {
        
        public string FlightNumber { get; set; }
        public int TicketCount { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        [ForeignKey("DepartureAirportId")]
        public int DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        [ForeignKey("ArrivalAirportId")]
        public int ArrivalAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }

        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
        public int Price_econom { get; set; }
        public int Price_biznes { get; set; }

        public int PassengerCount { get; set; }

        // Relation
        public ICollection<Ticket> Tickets { get; set; }
    }
}
