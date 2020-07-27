using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.repositories.Athletes
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly SubNineContext context;

        public AthleteRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<Athlete> GetAll(string search)
        {
            var query = this.context.Athletes.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.FirstName.Contains(search) || p.LastName.Contains(search)
                );
            }

            return query.ToList();
        }

        public Athlete GetOne(long id)
        {
            return this.context.Athletes.Where(a => a.Id == id).Single();
        }

        public IEnumerable<Athlete> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Athletes.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Athlete Create(Athlete a)
        {
            this.context.Athletes.Add(a);
            this.context.SaveChanges();

            return a;
        }

        public bool Delete(long id)
        {
            this.context.Athletes.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public Athlete Update(long id, Athlete updatedAthlete)
        {
            updatedAthlete.Id = id;
            this.context.Entry(updatedAthlete).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedAthlete;
        }
    }
}