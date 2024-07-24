using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Banners
{
    public class BannerCreateVM
    {
        [Required(ErrorMessage = "This input can't be empty")]
        public IFormFile Image { get; set; }
    }
}
