using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNineAPI.Entities;

namespace SubNineAPI.Repositories
{
    public class CountryRepository : ISubNineRepository<Country>
    {
        private readonly SubNineContext context;

        public CountryRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<Country> GetAll()
        {
            return this.context.Countries.ToList();
        }

        public Country GetOne(long id)
        {
            return this.context.Countries.Where(a => a.Id == id).Single();
        }

        public IEnumerable<Country> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Countries.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Country Create(Country a)
        {
            this.context.Countries.Add(a);
            this.context.SaveChanges();

            return a;
        }

        public bool Delete(long id)
        {
            this.context.Countries.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public Country Update(long id, Country updatedCountry)
        {
            updatedCountry.Id = id;
            this.context.Entry(updatedCountry).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedCountry;
        }
    }
}