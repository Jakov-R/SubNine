using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed
{
    public static class CitySeeder
    {
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
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
        }
    }
}