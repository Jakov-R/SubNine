using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SubNineContext context;

        public CategoryRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAll(string search)
        {
            var query = this.context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Name.Contains(search)
                );
            }

            return query.ToList();
        }

        public Category GetOne(long id)
        {
            return this.context.Categories.Where(a => a.Id == id).Single();
        }

        public IEnumerable<Category> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Categories.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Category Create(Category a)
        {
            this.context.Categories.Add(a);
            this.context.SaveChanges();

            return a;
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