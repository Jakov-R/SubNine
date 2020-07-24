using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SubNineAPI.Entities;
using SubNineAPI.Repositories;

namespace SubNineAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<SubNineContext>(options => options.UseSqlServer("Server=DESKTOP-VIQHUMA;Database=SubNine;Trusted_Connection=true;"));
            
            services.AddScoped<ISubNineRepository<Athlete>, AthleteRepository>();
            services.AddScoped<ISubNineRepository<City>, CityRepository>();
            services.AddScoped<ISubNineRepository<Country>, CountryRepository>();
            services.AddScoped<ISubNineRepository<Club>, ClubRepository>();
            services.AddScoped<ISubNineRepository<Discipline>, DisciplineRepository>();
            services.AddScoped<ISubNineRepository<Event>, EventRepository>();
            services.AddScoped<ISubNineRepository<Participation>, ParticipationRepository>();
            services.AddScoped<ISubNineRepository<RangList>, RangListRepository>();
            services.AddScoped<ISubNineRepository<Category>, CategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
