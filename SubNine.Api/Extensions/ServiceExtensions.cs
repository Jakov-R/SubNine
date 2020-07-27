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
using SubNine.Core.Repositories;
using SubNine.Data.Entities;

namespace SubNine.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Athlete>, AthleteRepository>();
            services.AddScoped<IRepository<City>, CityRepository>();
            services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddScoped<IRepository<Club>, ClubRepository>();
            services.AddScoped<IRepository<Discipline>, DisciplineRepository>();
            services.AddScoped<IRepository<Event>, EventRepository>();
            services.AddScoped<IRepository<Participation>, ParticipationRepository>();
            services.AddScoped<IRepository<RangList>, RangListRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
        }
    }
}