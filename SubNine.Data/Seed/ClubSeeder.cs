using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed
{
    public static class ClubSeeder
    {
        public static void SeedClubs(this ModelBuilder modelBuilder)
        {
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
        }
    }
}