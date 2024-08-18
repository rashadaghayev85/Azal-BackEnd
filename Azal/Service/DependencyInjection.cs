using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
           

            //services.AddScoped<IValidator<StudentCreateDto>, CountryCreateDtoValidator>();

           
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IBlogTranslateService, BlogTranslateService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IPlaneService, PlaneService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ISpecialOffersService, SpecialOfferService>();
            services.AddScoped<IPopularDirectionService, PopularDirectionService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<EmailService, EmailService>();

            

           
            return services;

        }
    }
}
