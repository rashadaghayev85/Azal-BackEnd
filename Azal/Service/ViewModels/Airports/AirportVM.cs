using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Airports
{
    public class AirportVM
    {
        public int Id { get; set; }
        public string AirportCode { get; set; }
        public List<AirportTranslate> AirportTranslates { get; set; }
    }
}
