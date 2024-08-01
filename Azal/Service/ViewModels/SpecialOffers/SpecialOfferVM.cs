using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.SpecialOffers
{
    public class SpecialOfferVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public List<SpecialOffersTransLate> SpecialOffersTransLates { get; set; }
    }
}
