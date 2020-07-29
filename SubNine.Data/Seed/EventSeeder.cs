using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed
{
    public static class EventSeeder
    {
        public static void SeedEvents(this ModelBuilder modelBuilder)
        {
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
        }
    }
}