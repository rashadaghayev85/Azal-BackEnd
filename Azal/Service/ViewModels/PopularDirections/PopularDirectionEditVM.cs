using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.PopularDirections
{
    public class PopularDirectionEditVM
    {
        public int Id { get; set; }

        public IFormFile? NewImage { get; set; }
        public string? Image { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int PriceEconom { get; set; }
        public int PriceBiznes { get; set; }
        public string Culture { get; set; }
    }
}
