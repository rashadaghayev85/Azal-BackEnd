using Domain.Models;
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
        public IEnumerable<SpecialOfferVM> SpecialOffers { get; set; }
        public IEnumerable<PopularDirectionVM> PopularDirections { get; set; }
        public IEnumerable<BlogVM> Blogs { get; set; }
    }
}
