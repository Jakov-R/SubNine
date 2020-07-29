using System;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Database
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
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Hrvatska"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bosna i Hercegovina"
                }
            );

             modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Zagreb",
                    CountryId = 1
                },
                new City
                {
                    Id = 2,
                    Name = "Split",
                    CountryId = 1
                },
                new City
                {
                    Id = 3,
                    Name = "Mostar",
                    CountryId = 2
                }
            );

            modelBuilder.Entity<Club>().HasData(
                new Club
                {
                    Id = 1,
                    Name = "AK Agram",
                    ShirtColor = "black",
                    CityId = 1
                },
                new Club
                {
                    Id = 2,
                    Name = "AK Dinamo-Zrinjevac",
                    ShirtColor = "blue",
                    CityId = 1
                },
                new Club
                {
                    Id = 3,
                    Name = "AK Zagreb",
                    ShirtColor = "blue/white",
                    CityId = 1
                }
            );

            modelBuilder.Entity<Athlete>().HasData(
                new Athlete
                {
                    Id = 1,
                    FirstName = "Jakov",
                    LastName = "Raguž",
                    DateOfBirth = new DateTime(1998, 8, 21),
                    Gender = "M",
                    ClubId = 1,
                    CountryId = 1
                },
                new Athlete
                {
                    Id = 2,
                    FirstName = "Martin",
                    LastName = "Poje",
                    DateOfBirth = new DateTime(1999, 5, 17),
                    Gender = "M",
                    ClubId = 2,
                    CountryId = 1
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "running"
                },
                new Category
                {
                    Id = 2,
                    Name = "jumping"
                }
            );

            modelBuilder.Entity<Discipline>().HasData(
                new Discipline
                {
                    Id = 1,
                    Name = "100m",
                    CategoryId = 1
                },
                new Discipline
                {
                    Id = 2,
                    Name = "long jump",
                    CategoryId = 2
                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Preliminary round"
                },
                new Event
                {
                    Id = 2,
                    Name = "Qualifications"
                },
                new Event
                {
                    Id = 3,
                    Name = "Heats"
                }
            );

            modelBuilder.Entity<Participation>().HasData(
                new Participation
                {
                    Id = 1,
                    AthleteId = 1,
                    DisciplineId = 1,
                    EventId = 3,
                    Result = 10.97
                },
                new Participation
                {
                    Id = 2,
                    AthleteId = 1,
                    DisciplineId = 2,
                    EventId = 3,
                    Result = 6.11
                }
            );

            modelBuilder.Entity<RangList>().HasData(
                new RangList
                {
                    Id = 1,
                    AthleteId = 1,
                    EventId = 3,
                    Place = 4
                },
                new RangList
                {
                    Id = 2,
                    AthleteId = 1,
                    EventId = 3,
                    Place = 2
                }
            );
        }
    }
}