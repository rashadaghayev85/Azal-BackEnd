using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AppUser : IdentityUser
    {
       
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string? Address { get; set; }
        public string DocumentExpiryDate { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
    }
}
