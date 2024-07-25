using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Blogs
{
    public class BlogCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
      
        public int LanguageId { get; set; }
    }
}
