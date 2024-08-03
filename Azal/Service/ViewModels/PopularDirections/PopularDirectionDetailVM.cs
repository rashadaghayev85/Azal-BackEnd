using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.PopularDirections
{
    public class PopularDirectionDetailVM
    {
        public string Image { get; set; }
        public int Price_azn { get; set; }
        public int Price_usd { get; set; }
        public PopularDirectionTranslate PopularDirectionTranslate { get; set; }
    }
}
