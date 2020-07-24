using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNineAPI.Entities;

namespace SubNineAPI.Repositories
{
    public class CategoryRepository : ISubNineRepository<Category>
    {
        private readonly SubNineContext context;
        public CategoryRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return this.context.Categories.ToList();
        }

        public Category GetOne(long id)
        {
            return this.context.Categories.Where(c => c.Id == id).Single();
        }

        public IEnumerable<Category> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Categories.Where(c => ids.Contains(c.Id)).ToList();
        }

        public Category Create(Category c)
        {
            this.context.Categories.Add(c);
            this.context.SaveChanges();

            return c;
        }

        public bool Delete(long id)
        {
            this.context.Categories.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public Category Update(long id, Category updatedCategory)
        {
            updatedCategory.Id = id;
            this.context.Entry(updatedCategory).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedCategory;
        }
    }
}