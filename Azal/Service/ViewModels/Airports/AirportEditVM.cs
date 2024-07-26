using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Airports
{
    public class AirportEditVM
    {
        public int Id { get; set; }

        
        public string? AirportCode { get; set; }
        public string? Location { get; set; }
        public string Culture { get; set; }
    }
}
