using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Blogs
{
    public class BlogDetailVM
    {
       
        public string Image { get; set; }
        
        public BlogTranslate BlogTranslate { get; set; }
    }
}
