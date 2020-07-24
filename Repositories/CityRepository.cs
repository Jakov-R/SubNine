using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNineAPI.Entities;

namespace SubNineAPI.Repositories
{
    public class CityRepository : ISubNineRepository<City>
    {
        public readonly SubNineContext context;

        public CityRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<City> GetAll()
        {
            return this.context.Cities.ToList();
        }

        public City GetOne(long id)
        {
            return this.context.Cities.Where(c => c.Id == id).Single();
        }

        public IEnumerable<City> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Cities.Where(c => ids.Contains(c.Id)).ToList();
        }

        public City Create(City c)
        {
            this.context.Cities.Add(c);
            this.context.SaveChanges();

            return c;
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