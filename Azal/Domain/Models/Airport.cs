using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Airport :BaseEntity
    {
        
        public string AirportCode { get; set; }
        public List<AirportTranslate> AirportTranslates { get; set; }

        // Relation
        [NotMapped]
        public ICollection<Flight> DepartingFlights { get; set; }
        [NotMapped]
        public ICollection<Flight> ArrivingFlights { get; set; }
    }
}
