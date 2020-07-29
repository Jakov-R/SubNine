using Microsoft.Extensions.DependencyInjection;
using SubNine.Core.repositories.Athletes;
using SubNine.Core.repositories.Categories;
using SubNine.Core.repositories.Cities;
using SubNine.Core.repositories.Clubs;
using SubNine.Core.repositories.Countries;
using SubNine.Core.repositories.Disciplines;
using SubNine.Core.repositories.Events;
using SubNine.Core.repositories.Participations;
using SubNine.Core.repositories.RangLists;
using SubNine.Data.Entities;

namespace SubNine.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IAthleteRepository, AthleteRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<IDisciplineRepository, DisciplineRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IParticipationRepository, ParticipationRepository>();
            services.AddScoped<IRangListRepository, RangListRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}