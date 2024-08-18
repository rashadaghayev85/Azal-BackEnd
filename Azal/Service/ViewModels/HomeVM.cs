using Domain.Models;
using Service.ViewModels.Airports;
using Service.ViewModels.Banners;
using Service.ViewModels.Blogs;
using Service.ViewModels.PopularDirections;
using Service.ViewModels.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<BannerVM> Banners { get; set; }
        public IEnumerable<AirportVM> Airports { get; set; }
        public IEnumerable<SpecialOfferVM> SpecialOffers { get; set; }
        public IEnumerable<PopularDirectionVM> PopularDirections { get; set; }
        public IEnumerable<BlogVM> Blogs { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime OutBound { get; set; }
        public DateTime Return { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }

    }
}
