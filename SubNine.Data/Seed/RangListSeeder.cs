using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed
{
    public static class RangListSeeder
    {
        public static void SeedRangLists(this ModelBuilder modelBuilder)
        {
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