using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Banners
{
    public class BannerEditVM
    {
        public string? Image { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
