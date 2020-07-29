using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed{
    public static class CountrySeeder
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
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
        }
    }
}