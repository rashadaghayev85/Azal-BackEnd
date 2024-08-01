using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PopularDirection : BaseEntity
    {
        public string Image { get; set; }
        public int Price_azn { get; set; }
        public int Price_usd { get; set; }
        public List<PopularDirectionTranslate> PopularDirectionTranslates { get; set; }
    }
}
