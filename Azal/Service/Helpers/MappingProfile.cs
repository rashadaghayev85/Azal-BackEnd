using AutoMapper;
using Domain.Models;
using Service.ViewModels.Airports;
using Service.ViewModels.Banners;
using Service.ViewModels.Blogs;
using Service.ViewModels.BlogTranslates;
using Service.ViewModels.Flights;
using Service.ViewModels.Languages;
using Service.ViewModels.Planes;
using Service.ViewModels.PopularDirections;
using Service.ViewModels.Settings;
using Service.ViewModels.SpecialOffers;
using Service.ViewModels.Tickets;
using Service.ViewModels.Users;
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
            CreateMap<BannerCreateVM, Banner>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageName)); ;
            CreateMap<BannerEditVM, Banner>();

            CreateMap<Language, LanguageVM>();
            CreateMap<LanguageCreateVM, Language>();
            CreateMap<LanguageEditVM, Language>();

            CreateMap<Blog, BlogVM>().ForMember(dest => dest.BlogTranslate, opt => opt.MapFrom(src => src.BlogTranslates));
            CreateMap<Blog, BlogDetailVM>().ForMember(dest => dest.BlogTranslate, opt => opt.MapFrom(src => src.BlogTranslates.FirstOrDefault()));
            CreateMap<BlogCreateVM, Blog>() ;
            CreateMap<Blog, BlogEditVM>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BlogTranslates.FirstOrDefault().Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.BlogTranslates.FirstOrDefault().Description))
                .ForMember(dest=>dest.Culture,opt=>opt.MapFrom(src=>src.BlogTranslates.FirstOrDefault().Language.Culture));
            CreateMap<BlogTranslate, BlogTranslateVM>();

            CreateMap<Airport, AirportVM>().ForMember(dest => dest.AirportTranslates, opt => opt.MapFrom(src => src.AirportTranslates));
            CreateMap<Airport, AirportDetailVM>().ForMember(dest => dest.AirportTranslate, opt => opt.MapFrom(src => src.AirportTranslates.FirstOrDefault()));
            CreateMap<AirportCreateVM, Airport>();
            CreateMap<Airport, AirportEditVM>().ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.AirportTranslates.FirstOrDefault().Location))
                .ForMember(dest => dest.Culture, opt => opt.MapFrom(src => src.AirportTranslates.FirstOrDefault().Language.Culture));

            CreateMap<Flight, FlightVM>().ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.DepartureAirport.Id))
            .ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.ArrivalAirport.Id));
            CreateMap<Flight, FlightDetailVM>().ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.DepartureAirport.AirportCode))
                .ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.ArrivalAirport.AirportCode));
            CreateMap<FlightCreateVM, Flight>().ForMember(dest => dest.DepartureAirportId, opt => opt.MapFrom(src => src.DepartureAirport))
            .ForMember(dest => dest.ArrivalAirportId, opt => opt.MapFrom(src => src.ArrivalAirport))
            .ForMember(dest => dest.PlaneId, opt => opt.MapFrom(src => src.Plane))
            .ForMember(dest => dest.DepartureAirport, opt => opt.Ignore())
            .ForMember(dest => dest.ArrivalAirport, opt => opt.Ignore())
            .ForMember(dest => dest.Plane, opt => opt.Ignore());
           // CreateMap<Flight, FlightEditVM>();
            CreateMap<FlightEditVM, Flight>().ForMember(dest => dest.DepartureAirportId, opt => opt.MapFrom(src => src.DepartureAirport))
                .ForMember(dest => dest.Price_econom, opt => opt.MapFrom(src => src.Price_econom))
                .ForMember(dest => dest.Price_biznes, opt => opt.MapFrom(src => src.Price_biznes))
            .ForMember(dest => dest.ArrivalAirportId, opt => opt.MapFrom(src => src.ArrivalAirport))
            .ForMember(dest => dest.PlaneId, opt => opt.MapFrom(src => src.Plane))
            .ForMember(dest => dest.DepartureAirport, opt => opt.Ignore())
            .ForMember(dest => dest.ArrivalAirport, opt => opt.Ignore())
 
            .ForMember(dest => dest.Plane, opt => opt.Ignore()).ReverseMap();

            CreateMap<Plane, PlaneVM>();
            CreateMap<Plane, PlaneDetailVM>();
            CreateMap<PlaneCreateVM, Plane>();
            CreateMap<Plane, PlaneEditVM>();

            CreateMap<Ticket, TicketVM>().ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.Flight.ArrivalAirport.AirportTranslates.SingleOrDefault().Location))
                                         .ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.Flight.DepartureAirport.AirportTranslates.SingleOrDefault().Location));
                                         
            CreateMap<TicketCreateVM, Ticket>().ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.Flight))
                                               .ForMember(dest => dest.Flight, opt => opt.Ignore());

            CreateMap<SpecialOffer, SpecialOfferVM>().ForMember(dest => dest.SpecialOffersTransLates, opt => opt.MapFrom(src => src.SpecialOffersTransLates));
            CreateMap<SpecialOffer, SpecialOfferDetailVM>().ForMember(dest => dest.SpecialOffersTransLate, opt => opt.MapFrom(src => src.SpecialOffersTransLates.FirstOrDefault()));
            CreateMap<SpecialOfferCreateVM, SpecialOffer>();
            CreateMap<SpecialOffer, SpecialOfferEditVM>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SpecialOffersTransLates.FirstOrDefault().Name))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.SpecialOffersTransLates.FirstOrDefault().Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.SpecialOffersTransLates.FirstOrDefault().Description))
                .ForMember(dest => dest.Culture, opt => opt.MapFrom(src => src.SpecialOffersTransLates.FirstOrDefault().Language.Culture));



            CreateMap<PopularDirection, PopularDirectionVM>().ForMember(dest => dest.PopularDirectionTranslates, opt => opt.MapFrom(src => src.PopularDirectionTranslates));
            CreateMap<PopularDirection, PopularDirectionDetailVM>().ForMember(dest => dest.PopularDirectionTranslate, opt => opt.MapFrom(src => src.PopularDirectionTranslates.FirstOrDefault()));
            CreateMap<PopularDirectionCreateVM, PopularDirection>();
            CreateMap<PopularDirection, PopularDirectionEditVM>().ForMember(dest => dest.City, opt => opt.MapFrom(src => src.PopularDirectionTranslates.FirstOrDefault().City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.PopularDirectionTranslates.FirstOrDefault().Country))
               
                .ForMember(dest => dest.Culture, opt => opt.MapFrom(src => src.PopularDirectionTranslates.FirstOrDefault().Language.Culture));

            CreateMap<Setting, SettingEditVM>();

            CreateMap<UserEditVM, AppUser>().ReverseMap();
        }
    }
}
