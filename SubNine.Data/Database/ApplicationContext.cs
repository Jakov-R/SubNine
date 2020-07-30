using System;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;
using SubNine.Data.Seed;

namespace SubNine.Data.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {}

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<RangList> RangLists { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedAthletes();
            modelBuilder.SeedCategories();
            modelBuilder.SeedCities();
            modelBuilder.SeedClubs();
            modelBuilder.SeedCountries();
            modelBuilder.SeedDisciplines();
            modelBuilder.SeedEvents();
            modelBuilder.SeedParticipations();
            modelBuilder.SeedRangLists();
        }
    }
}