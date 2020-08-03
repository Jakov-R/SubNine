using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : BaseController
    {
        private readonly IEventRepository subNineRepository;
        private readonly IMapper mapper;

        public EventController(
            IEventRepository subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDetailMore>> GetEvents([FromQuery] string search)
        {
            var eventt = this.subNineRepository.GetAll(search);
            var eventtDTO = this.mapper.Map<IEnumerable<EventDetailMore>>(eventt);

            return Ok(eventtDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDetailMore> GetEvent(long id)
        {
            var eventt = this.subNineRepository.GetOne(id);
            var eventtDto = this.mapper.Map<EventDetailMore>(eventt);

            return Ok(eventtDto);
        }

        [HttpPost]
        public ActionResult<EventDetailMore> CreateEvent(EventCreate eventtDTO)
        {
            var eventt = this.mapper.Map<Event>(eventtDTO);
            eventt = this.subNineRepository.Create(eventt);

            return this.mapper.Map<EventDetailMore>(eventt);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteEvent(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<EventDetailMore> UpdateEvent(long id, [FromBody] Event updatedEvent)
        {
            var eventt = this.subNineRepository.Update(id, updatedEvent);
            var eventtResult = this.mapper.Map<EventDetailMore>(eventt);

            return eventtResult;
        }

        [HttpPatch("{id}")]
        public ActionResult<EventDetail> Patch(int id, [FromBody]JsonPatchDocument<Event> doc)
        {
            var eventt = this.subNineRepository.GetOne(id);
            this.subNineRepository.Patch(id, doc);
            return Ok(eventt);
        }
    }
}