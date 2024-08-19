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

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? FatherName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentExpiryDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ReservationNumber { get; set; }
        public string TicketNumber { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public DateTime PurchaseDate { get; set; }= DateTime.Now;   



    }
}
