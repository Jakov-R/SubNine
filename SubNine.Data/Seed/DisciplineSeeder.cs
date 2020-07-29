using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed
{
    public static class DisciplineSeeder
    {
        public static void SeedDisciplines(this ModelBuilder modelBuilder)
        {
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
        }
    }
}