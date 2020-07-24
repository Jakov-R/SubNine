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

            modelBuilder.Entity<Discipline>().HasData(
                new Discipline
                {
                    Id = 1,
                    Name = "100m"
                },
                new Discipline
                {
                    Id = 2,
                    Name = "long jump"
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
                    Result = 10.97
                },
                new Participation
                {
                    Id = 2,
                    Result = 22.22
                }
            );

            modelBuilder.Entity<RangList>().HasData(
                new RangList
                {
                    Id = 1,
                    Place = 4
                },
                new RangList
                {
                    Id = 2,
                    Place = 2
                }
            );
        }
    }
}