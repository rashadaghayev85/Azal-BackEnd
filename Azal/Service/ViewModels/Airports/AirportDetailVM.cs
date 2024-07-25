using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Airports
{
    public class AirportDetailVM
    {
        public string Name { get; set; }

        public AirportTranslate AirportTranslate { get; set; }
    }
}
