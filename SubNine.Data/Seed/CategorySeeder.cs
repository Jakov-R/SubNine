using Microsoft.EntityFrameworkCore;
using SubNine.Data.Entities;

namespace SubNine.Data.Seed
{
    public static class CategorySeeder
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
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
        }
    }
}