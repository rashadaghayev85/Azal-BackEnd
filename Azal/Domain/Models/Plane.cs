using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Plane :BaseEntity
    {
        
        public string Model { get; set; }
        public int Capacity { get; set; }

        // Relation
        public ICollection<Flight> Flights { get; set; }
    }
}
