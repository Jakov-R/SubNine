using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;

namespace SubNine.Core.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        public Event Patch(long id, JsonPatchDocument<Event> doc);
    }
    
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext context;

        public EventRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Event> GetAll(string search)
        {
            var query = this.context.Events.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                /* simple search */
                query = query.Where(
                    p => p.Name.Contains(search)
                );
            }

            return query.ToList();
        }

        public Event GetOne(long id)
        {
            return this.context.Events
            .Where(a => a.Id == id)
            .Include( e => e.Participations)
            .Include(e => e.RangLists)
            .Single();
        }

        public IEnumerable<Event> GetMultiple(IEnumerable<long> ids)
        {
            return this.context.Events.Where(a => ids.Contains(a.Id)).ToList();
        }

        public Event Create(Event a)
        {
            this.context.Events.Add(a);
            this.context.SaveChanges();

            return a;
        }

        public bool Delete(long id)
        {
            this.context.Events.Remove(this.GetOne(id));
            this.context.SaveChanges();

            return true;
        }

        public Event Update(long id, Event updatedEvent)
        {
            updatedEvent.Id = id;
            this.context.Entry(updatedEvent).State = EntityState.Modified;
            this.context.SaveChanges();

            return updatedEvent;
        }

        public Event Patch(long id, JsonPatchDocument<Event> doc)
        {
            var eventt = this.GetOne(id);
            doc.ApplyTo(eventt);
            this.context.SaveChanges();
            return eventt;
        }
    }
}