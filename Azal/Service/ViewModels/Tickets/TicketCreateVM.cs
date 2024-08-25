using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Tickets
{
    public class TicketCreateVM
    {
      
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? FatherName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentExpiryDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? ReservationNumber { get; set; }
        public string? TicketNumber { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Flight can't be empty")]
        public int Flight { get; set; }
        public int PassengerCount { get; set; }
    }
}
