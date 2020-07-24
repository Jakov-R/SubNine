using System;
using Microsoft.EntityFrameworkCore;

namespace SubNineAPI.Entities
{
    public class SubNineContext : DbContext
    {
        public SubNineContext(DbContextOptions<SubNineContext> options)
        : base(options)
        {}

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<RangList> RangLists { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>().HasData(
                new Athlete
                {
                    Id = 1,
                    FirstName = "Jakov",
                    LastName = "Raguž",
                    DateOfBirth = new DateTime(1998, 8, 21),
                    Gender = "M"
                },
                new Athlete
                {
                    Id = 2,
                    FirstName = "Martin",
                    LastName = "Poje",
                    DateOfBirth = new DateTime(1999, 5, 17),
                    Gender = "M"
                }
            );
            
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Zagreb"
                },
                new City
                {
                    Id = 2,
                    Name = "Split"
                },
                new City
                {
                    Id = 3,
                    Name = "Mostar"
                }
            );
            
            modelBuilder.Entity<Club>().HasData(
                new Club
                {
                    Id = 1,
                    Name = "AK Agram",
                    ShirtColor = "black"
                },
                new Club
                {
                    Id = 2,
                    Name = "AK Dinamo-Zrinjevac",
                    ShirtColor = "blue"
                },
                new Club
                {
                    Id = 3,
                    Name = "AK Zagreb",
                    ShirtColor = "blue/white"
                }
            );
        }
    }
}