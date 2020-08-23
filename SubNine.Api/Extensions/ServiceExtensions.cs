using Microsoft.Extensions.DependencyInjection;
using SubNine.Api.Services;
using SubNine.Core.Repositories;

namespace SubNine.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            //repositories
            services.AddScoped<IAthleteRepository, AthleteRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<IDisciplineRepository, DisciplineRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IParticipationRepository, ParticipationRepository>();
            services.AddScoped<IRangListRepository, RangListRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAthleteService, AthleteService>();
        }
    }
}