using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.repositories.RangLists
{
    public class RangListRepository : IRangListRepository
    {
        private readonly SubNineContext context;

        public RangListRepository(SubNineContext context)
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

            return query.ToList();
        }

        public RangList GetOne(long id)
        {
            return this.context.RangLists.Where(a => a.Id == id).Single();
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
    }
}