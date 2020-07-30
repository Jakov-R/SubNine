using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Core.Repositories.Clubs
{
    public interface IClubRepository : IRepository<Club>{}
    
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationContext context;

        public ClubRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Club> GetAll(string search)
        {
            var query = this.context.Clubs.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Name.Contains(search)
                );
            }

            query = query
            .Include(c => c.City);

            return query.ToList();
        }

        public Club GetOne(long id)
        {
            return this.context.Clubs
            .Where(a => a.Id == id)
            .Include(c => c.City)
            .Single();
        }

        public IEnumerable<Club> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Clubs.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Club Create(Club a)
        {
            this.context.Clubs.Add(a);
            this.context.SaveChanges();

            return a;
        }

        public bool Delete(long id)
        {
            this.context.Clubs.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public Club Update(long id, Club updatedClub)
        {
            updatedClub.Id = id;
            this.context.Entry(updatedClub).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedClub;
        }
    }
}