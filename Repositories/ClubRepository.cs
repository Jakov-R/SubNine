using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNineAPI.Entities;

namespace SubNineAPI.Repositories
{
    public class ClubRepository : ISubNineRepository<Club>
    {
        private readonly SubNineContext context;

        public ClubRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<Club> GetAll()
        {
            return this.context.Clubs.ToList();
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