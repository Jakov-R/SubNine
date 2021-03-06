using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        public Country Patch(long id, JsonPatchDocument<Country> doc);
    }
    
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationContext context;

        public CountryRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Country> GetAll(string search)
        {
            var query = this.context.Countries.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Name.Contains(search)
                );
            }

            query = query
            .Include(c => c.Cities);

            return query.ToList();
        }

        public Country GetOne(long id)
        {
            return this.context.Countries
            .Where(a => a.Id == id)
            .Include(c => c.Cities)
            .Single();
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

        public Country Patch(long id, JsonPatchDocument<Country> doc)
        {
            var country = this.GetOne(id);
            doc.ApplyTo(country);
            this.context.SaveChanges();
            return country;
        }
    }
}