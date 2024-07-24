using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BlogTranslate : BaseEntity
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

    }
}
