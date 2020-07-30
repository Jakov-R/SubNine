using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.Repositories.Countries
{
    public interface ICountryRepository : IRepository<Country>{}
    
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

            return query.ToList();
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