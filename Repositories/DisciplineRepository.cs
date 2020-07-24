using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNineAPI.Entities;

namespace SubNineAPI.Repositories
{
    public class DisciplineRepository : ISubNineRepository<Discipline>
    {
        private readonly SubNineContext context;

        public DisciplineRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<Discipline> GetAll()
        {
            return this.context.Disciplines.ToList();
        }

        public Discipline GetOne(long id)
        {
            return this.context.Disciplines.Where(a => a.Id == id).Single();
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
    }
}