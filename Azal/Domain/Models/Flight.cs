using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Flight :BaseEntity
    {
        
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        // Foreign Keys
        public int DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }

        public int ArrivalAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }

        public int PlaneId { get; set; }
        public Plane Plane { get; set; }

        // Relation
        public ICollection<Ticket> Tickets { get; set; }
    }
}
