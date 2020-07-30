using Microsoft.Extensions.DependencyInjection;
using SubNine.Core.Repositories.Athletes;
using SubNine.Core.Repositories.Categories;
using SubNine.Core.Repositories.Cities;
using SubNine.Core.Repositories.Clubs;
using SubNine.Core.Repositories.Countries;
using SubNine.Core.Repositories.Disciplines;
using SubNine.Core.Repositories.Events;
using SubNine.Core.Repositories.Participations;
using SubNine.Core.Repositories.RangLists;

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