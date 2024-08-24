using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Blogs
{
    public class BlogVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public List<BlogTranslate> BlogTranslate { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
    }
}
