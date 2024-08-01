using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SpecialOffersTransLate : BaseEntity
    {
        public int SpecialOfferId { get; set; }
        public SpecialOffer SpecialOffer { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
