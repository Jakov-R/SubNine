using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.Repositories
{
    public interface IParticipationRepository : IRepository<Participation>
    {
        public Participation Patch(long id, JsonPatchDocument<Participation> doc);
    }
    
    public class ParticipationRepository : IParticipationRepository
    {
        private readonly ApplicationContext context;

        public ParticipationRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Participation> GetAll(string search)
        {
            var query = this.context.Participations.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Result.ToString().Contains(search)
                );
            }

            query = query
            .Include(p => p.Athlete)
            .Include(p => p.Event)
            .Include(p => p.Discipline);

            return query.ToList();
        }

        public Participation GetOne(long id)
        {
            return this.context.Participations.Where(a => a.Id == id)
            .Include(p => p.Athlete)
            .Include(p => p.Event)
            .Include(p => p.Discipline)
            .Single();
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

        public Participation Patch(long id, JsonPatchDocument<Participation> doc)
        {
            var participation = this.GetOne(id);
            doc.ApplyTo(participation);
            this.context.SaveChanges();
            return participation;
        }
    }
}