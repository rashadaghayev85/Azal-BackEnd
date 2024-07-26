using AutoMapper;
using Domain.Models;
using Service.ViewModels.Airports;
using Service.ViewModels.Banners;
using Service.ViewModels.Blogs;
using Service.ViewModels.BlogTranslates;
using Service.ViewModels.Flights;
using Service.ViewModels.Languages;
using Service.ViewModels.Planes;
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

            CreateMap<Airport, AirportVM>().ForMember(dest => dest.AirportTranslates, opt => opt.MapFrom(src => src.AirportTranslates));
            CreateMap<Airport, AirportDetailVM>().ForMember(dest => dest.AirportTranslate, opt => opt.MapFrom(src => src.AirportTranslates.FirstOrDefault()));
            CreateMap<AirportCreateVM, Airport>();
            CreateMap<Airport, AirportEditVM>().ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.AirportTranslates.FirstOrDefault().Location))
                .ForMember(dest => dest.Culture, opt => opt.MapFrom(src => src.AirportTranslates.FirstOrDefault().Language.Culture));

            CreateMap<Flight, FlightVM>();
            CreateMap<Flight, FlightDetailVM>();
            CreateMap<FlightCreateVM, Flight>().ForMember(dest => dest.DepartureAirportId, opt => opt.MapFrom(src => src.DepartureAirport))
            .ForMember(dest => dest.ArrivalAirportId, opt => opt.MapFrom(src => src.ArrivalAirport))
            .ForMember(dest => dest.PlaneId, opt => opt.MapFrom(src => src.Plane))
            .ForMember(dest => dest.DepartureAirport, opt => opt.Ignore())
            .ForMember(dest => dest.ArrivalAirport, opt => opt.Ignore())
            .ForMember(dest => dest.Plane, opt => opt.Ignore());
            CreateMap<Flight, FlightEditVM>();
            
            CreateMap<Plane, PlaneVM>();
            CreateMap<Plane, PlaneDetailVM>();
            CreateMap<PlaneCreateVM, Plane>();
            CreateMap<Plane, PlaneEditVM>();

        }
    }
}
