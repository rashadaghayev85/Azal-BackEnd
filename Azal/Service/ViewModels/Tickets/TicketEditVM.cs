using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Tickets
{
    public class TicketEditVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentExpiryDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Flight Flight { get; set; }
    }
}
