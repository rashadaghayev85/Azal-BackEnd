using AutoMapper;
using Domain.Models;
using Service.ViewModels.Banners;
using Service.ViewModels.Blogs;
using Service.ViewModels.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
           

            CreateMap<Banner, BannerVM>();
            CreateMap<BannerCreateVM, Banner>();
            CreateMap<BannerEditVM, Banner>();

            CreateMap<Language, LanguageVM>();
            CreateMap<LanguageCreateVM, Language>();
            CreateMap<LanguageEditVM, Language>();

            CreateMap<Blog, BlogVM>();
            CreateMap<BlogCreateVM, Blog>();
            CreateMap<BlogEditVM, Blog>();


        }
    }
}
