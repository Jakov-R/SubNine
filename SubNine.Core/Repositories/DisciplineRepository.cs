using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.Repositories
{
    public interface IDisciplineRepository : IRepository<Discipline>
    {
        public Discipline Patch(long id, JsonPatchDocument<Discipline> doc);
    }
    
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly ApplicationContext context;

        public DisciplineRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Discipline> GetAll(string search)
        {
            var query = this.context.Disciplines.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Name.Contains(search)
                );
            }

            query = query
            .Include(d => d.Category);

            return query.ToList();
        }

        public Discipline GetOne(long id)
        {
            return this.context.Disciplines
            .Where(a => a.Id == id)
            .Include(d => d.Category)
            .Single();
        }

        public IEnumerable<Discipline> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Disciplines.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Discipline Create(Discipline a)
        {
            this.context.Disciplines.Add(a);
            this.context.SaveChanges();

            return a;
        }

        public bool Delete(long id)
        {
            this.context.Disciplines.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public Discipline Update(long id, Discipline updatedDiscipline)
        {
            updatedDiscipline.Id = id;
            this.context.Entry(updatedDiscipline).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedDiscipline;
        }

        public Discipline Patch(long id, JsonPatchDocument<Discipline> doc)
        {
            var discipline = this.GetOne(id);
            doc.ApplyTo(discipline);
            this.context.SaveChanges();
            return discipline;
        }
    }
}