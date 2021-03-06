using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.Repositories
{
    public interface IRangListRepository : IRepository<RangList>
    {
        public RangList Patch(long id, JsonPatchDocument<RangList> doc);
    }
    
    public class RangListRepository : IRangListRepository
    {
        private readonly ApplicationContext context;

        public RangListRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<RangList> GetAll(string search)
        {
            var query = this.context.RangLists.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Place.ToString().Contains(search)
                );
            }

            query = query
            .Include(r => r.Athlete)
            .Include(r => r.Event);

            return query.ToList();
        }

        public RangList GetOne(long id)
        {
            return this.context.RangLists
            .Where(a => a.Id == id)
            .Include(r => r.Athlete)
            .Include(r => r.Event)
            .Single();
        }

        public IEnumerable<RangList> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.RangLists.Where(a => ids.Contains(a.Id)).ToList();
        }

        public RangList Create(RangList a)
        {
            this.context.RangLists.Add(a);
            this.context.SaveChanges();

            return a;
        }

        public bool Delete(long id)
        {
            this.context.RangLists.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public RangList Update(long id, RangList updatedRangList)
        {
            updatedRangList.Id = id;
            this.context.Entry(updatedRangList).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedRangList;
        }

        public RangList Patch(long id, JsonPatchDocument<RangList> doc)
        {
            var rangList = this.GetOne(id);
            doc.ApplyTo(rangList);
            this.context.SaveChanges();
            return rangList;
        }
    }
}