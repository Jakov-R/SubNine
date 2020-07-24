using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubNineAPI.Entities;

namespace SubNineAPI.Repositories
{
    public class EventRepository : ISubNineRepository<Event>
    {
        private readonly SubNineContext context;

        public EventRepository(SubNineContext context)
        {
            this.context = context;
        }

        public IEnumerable<Event> GetAll()
        {
            return this.context.Events.ToList();
        }

        public Event GetOne(long id)
        {
            return this.context.Events.Where(a => a.Id == id).Single();
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
    }
}