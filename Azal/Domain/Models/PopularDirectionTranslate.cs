using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PopularDirectionTranslate : BaseEntity
    {
        public int PopularDirectionId { get; set; }
        public PopularDirection PopularDirection { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
    }
}
