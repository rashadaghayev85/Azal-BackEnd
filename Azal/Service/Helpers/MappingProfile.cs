using AutoMapper;
using Domain.Models;
using Service.ViewModels.Banners;
using Service.ViewModels.Blogs;
using Service.ViewModels.BlogTranslates;
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

            CreateMap<Blog, BlogVM>().ForMember(dest => dest.BlogTranslate, opt => opt.MapFrom(src => src.BlogTranslates));
            CreateMap<Blog, BlogDetailVM>().ForMember(dest => dest.BlogTranslate, opt => opt.MapFrom(src => src.BlogTranslates.FirstOrDefault()));
            CreateMap<BlogCreateVM, Blog>();
            CreateMap<Blog, BlogEditVM>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BlogTranslates.FirstOrDefault().Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.BlogTranslates.FirstOrDefault().Description))
                .ForMember(dest=>dest.Culture,opt=>opt.MapFrom(src=>src.BlogTranslates.FirstOrDefault().Language.Culture));
            CreateMap<BlogTranslate, BlogTranslateVM>();



        }
    }
}
