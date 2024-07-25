using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AirportTranslate :BaseEntity
    {
        public int AirportId { get; set; }
        public Airport Airport { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

       
        public string Location { get; set; }
    }
}
