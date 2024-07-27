using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket :BaseEntity
    {
       
        //public string SeatNumber { get; set; }
        public int Price_az { get; set; }
        public int Price_usd { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public DateTime PurchaseDate { get; set; }= DateTime.Now;   



    }
}
