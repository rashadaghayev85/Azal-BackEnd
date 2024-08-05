using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.PopularDirections
{
    public class PopularDirectionCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
       
        public int Price_azn { get; set; }
        public int Price_usd { get; set; }

        public int LanguageId { get; set; }
    }
}
