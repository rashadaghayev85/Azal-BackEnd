using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe.Tax;

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
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IFLightRepository, FlightRepository>();
            services.AddScoped<IPlaneRepository, PlaneRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ISpecialOffersRepository, SpecialOffersRepository>();
            services.AddScoped<IPopularDirectionRepository, PopularDirectionRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
			services.AddScoped<IContactRepository, ContactRepository>();
			return services;
		}
    }
}
