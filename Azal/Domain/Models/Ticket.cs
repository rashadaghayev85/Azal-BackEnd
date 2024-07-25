using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket :BaseEntity
    {
       
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }

        // Foreign Keys
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
