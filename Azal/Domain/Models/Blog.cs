using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Blog:BaseEntity
    {
        public string Image { get; set; }
        public List<BlogTranslate> BlogTranslates { get; set; }
    }
}
