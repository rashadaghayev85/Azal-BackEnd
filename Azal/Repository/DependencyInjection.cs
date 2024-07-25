using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IBlogTranslateRepository, BlogTranslateRepository>();



            return services;

        }
    }
}
