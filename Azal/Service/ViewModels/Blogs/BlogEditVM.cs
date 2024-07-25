using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Blogs
{
    public class BlogEditVM
    {
        public int Id { get; set; }
      
        public IFormFile ? NewImage { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Culture { get; set; }

    }
}
