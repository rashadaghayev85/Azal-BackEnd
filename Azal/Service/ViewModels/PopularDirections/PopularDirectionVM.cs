using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.PopularDirections
{
    public class PopularDirectionVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int PriceEconom { get; set; }
        public int PriceBiznes { get; set; }
        public List<PopularDirectionTranslate> PopularDirectionTranslates { get; set; }
    }
}
