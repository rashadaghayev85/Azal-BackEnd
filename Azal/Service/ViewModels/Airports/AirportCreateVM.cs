using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Airports
{
    public class AirportCreateVM
    {
       
        public string AirportCode { get; set; }
        public string Location { get; set; }

        public int Language { get; set; }
    }
}
