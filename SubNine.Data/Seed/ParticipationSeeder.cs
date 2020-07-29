using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed
{
    public static class ParticipationSeeder
    {
        public static void SeedParticipations(this ModelBuilder modelBuilder)
        {
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
        }
    }
}