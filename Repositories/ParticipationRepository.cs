using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNineAPI.Entities;

namespace SubNineAPI.Repositories
{
    public class ParticipationRepository : ISubNineRepository<Participation>
    {
        private readonly SubNineContext context;

        public ParticipationRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<Participation> GetAll()
        {
            return this.context.Participations.ToList();
        }

        public Participation GetOne(long id)
        {
            return this.context.Participations.Where(a => a.Id == id).Single();
        }

        public IEnumerable<Participation> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Participations.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Participation Create(Participation a)
        {
            this.context.Participations.Add(a);
            this.context.SaveChanges();

            return a;
        }

        public bool Delete(long id)
        {
            this.context.Participations.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public Participation Update(long id, Participation updatedParticipation)
        {
            updatedParticipation.Id = id;
            this.context.Entry(updatedParticipation).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedParticipation;
        }
    }
}