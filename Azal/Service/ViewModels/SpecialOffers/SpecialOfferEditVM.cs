using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.SpecialOffers
{
    public class SpecialOfferEditVM
    {
        public int Id { get; set; }

        public IFormFile? NewImage { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string Culture { get; set; }
    }
}
