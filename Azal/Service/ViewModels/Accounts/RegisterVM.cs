using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Accounts
{
    public class RegisterVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string? FatherName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }




        [Required]
        public DateTime BirthDay { get; set; }
    
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public string Country { get; set; }
        public string Address { get; set; }
        [Required]
        public string DocumentExpiryDate { get; set; }
       
        [Required]
        public string DocumentNumber { get; set; }
    }
}
