using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.repositories.Cities
{
    public class CityRepository : ICityRepository
    {
        private readonly SubNineContext context;

        public CityRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<City> GetAll(string search)
        {
            var query = this.context.Cities.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Name.Contains(search)
                );
            }

            return query.ToList();
        }

        public City GetOne(long id)
        {
            return this.context.Cities.Where(a => a.Id == id).Single();
        }

        public IEnumerable<City> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Cities.Where(a => ids.Contains(a.Id)).ToList();
        }

        public City Create(City a)
        {
            this.context.Cities.Add(a);
            this.context.SaveChanges();

            return a;
        }

        public bool Delete(long id)
        {
            this.context.Cities.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public City Update(long id, City updatedCity)
        {
            updatedCity.Id = id;
            this.context.Entry(updatedCity).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedCity;
        }
    }
}