using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Core.Repositories
{
    public interface IAthleteRepository : IRepository<Athlete>
    {
        public Athlete Patch(long id, JsonPatchDocument<Athlete> doc);
        List<Athlete> GetPaginatedAthletes(int page = 1, string? search = null, string? sort = null);

        int PerPage { get; set; }

        int Count(string search);
    }
    
    public class AthleteRepository : IAthleteRepository
    {
        private readonly ApplicationContext context;

        public int PerPage { get; set; } = 4;

        public AthleteRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Athlete> GetAll(string search)
        {
            var query = this.context.Athletes.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query
                .Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search));
            }
            query = query
            .Include(a => a.Club)
            .Include(a => a.Country);
            return query.ToList();
        }

        public Athlete GetOne(long id)
        {
            return this.context.Athletes
            .Where(a => a.Id == id)
            .Include(a => a.Club)
            .Include(a => a.Country)
            .Single();
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

        public Athlete Patch(long id, JsonPatchDocument<Athlete> doc)
        {
            var athlete = this.GetOne(id);
            doc.ApplyTo(athlete);
            this.context.SaveChanges();
            return athlete;
        }

        public List<Athlete> GetPaginatedAthletes(int page, string search, string sort)
        {
            var query = this.context.Athletes.AsQueryable();
            
            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.FirstName.Contains(search) || a.LastName.Contains(search));
            }

            if(!string.IsNullOrEmpty(sort))
            {
                string[] elements = sort.Split(":");
                query = query.OrderByDescending(a => a.LastName);
            }

            return query.Skip((page-1) * this.PerPage)
            .Take(this.PerPage)
            .ToList();

        }

        public int Count(string search)
        {
            var query = this.context.Athletes.AsQueryable();
            
            if(!string.IsNullOrEmpty(search))
            {
                return query.Count(a => a.FirstName.Contains(search) || a.LastName.Contains(search));
            }

            return query.Count();
        }
    }
}