using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.repositories.Clubs
{
    public class ClubRepository : IClubRepository
    {
        private readonly SubNineContext context;

        public ClubRepository(SubNineContext context)
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

            return query.ToList();
        }

        public Club GetOne(long id)
        {
            return this.context.Clubs.Where(a => a.Id == id).Single();
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