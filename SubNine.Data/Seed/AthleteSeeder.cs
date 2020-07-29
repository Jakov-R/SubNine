using System;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed
{
    public static class AthleteSeeder
    {
        public static void SeedAthletes(this ModelBuilder modelBuilder)
        {
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
        }
    }
}