using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories.Events;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : BaseController
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;

        public EventController(
            IEventRepository eventRepository,
            IMapper mapper
        )
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDetailDTO>> GetEvents([FromQuery] string search)
        {
            var eventt = this.eventRepository.GetAll(search);
            var eventtDTO = this.mapper.Map<IEnumerable<EventDetailDTO>>(eventt);

            return Ok(eventtDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDetailDTO> GetEvent(long id)
        {
            var eventt = this.eventRepository.GetOne(id);
            var eventtDto = this.mapper.Map<EventDetailDTO>(eventt);

            return Ok(eventtDto);
        }

        [HttpPost]
        public ActionResult<EventDetailDTO> CreateEvent(EventCreateDTO eventtDTO)
        {
            var eventt = this.mapper.Map<Event>(eventtDTO);
            eventt = this.eventRepository.Create(eventt);

            return this.mapper.Map<EventDetailDTO>(eventt);
        }

        [HttpPatch("{id}")]
        public ActionResult<EventDetailDTO> Patch(long id, [FromBody]JsonPatchDocument<Event> doc)
        {
            var eventResult = this.eventRepository.GetOne(id);
            doc.ApplyTo(eventResult, ModelState);

            return Ok(this.mapper.Map<EventDetailDTO>(eventResult));
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteEvent(long id)
        {
            return new { success = this.eventRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<EventDetailDTO> UpdateEvent(long id, [FromBody] Event updatedEvent)
        {
            var eventt = this.eventRepository.Update(id, updatedEvent);
            var eventtResult = this.mapper.Map<EventDetailDTO>(eventt);

            return eventtResult;
        }
    }
}