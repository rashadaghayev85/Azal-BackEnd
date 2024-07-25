using Microsoft.Extensions.DependencyInjection;
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




            return services;

        }
    }
}
