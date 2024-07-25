using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Airport :BaseEntity
    {
        
        public string Location { get; set; }
        public List<AirportTranslate> AirportTranslates { get; set; }

        // Relation
        public ICollection<Flight> DepartingFlights { get; set; }
        public ICollection<Flight> ArrivingFlights { get; set; }
    }
}
