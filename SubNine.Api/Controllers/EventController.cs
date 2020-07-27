using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : AppController
    {
        private readonly IRepository<Event> subNineRepository;
        private readonly IMapper mapper;

        public EventController(
            IRepository<Event> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDetailDTO>> GetEvents([FromQuery] string search)
        {
            var eventt = this.subNineRepository.GetAll(search);
            var eventtDTO = this.mapper.Map<IEnumerable<EventDetailDTO>>(eventt);

            return Ok(eventtDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDetailDTO> GetEvent(long id)
        {
            var eventt = this.subNineRepository.GetOne(id);
            var eventtDto = this.mapper.Map<EventDetailDTO>(eventt);

            return Ok(eventtDto);
        }

        [HttpPost]
        public ActionResult<EventDetailDTO> CreateEvent(EventCreateDTO eventtDTO)
        {
            var eventt = this.mapper.Map<Event>(eventtDTO);
            eventt = this.subNineRepository.Create(eventt);

            return this.mapper.Map<EventDetailDTO>(eventt);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteEvent(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<EventDetailDTO> UpdateEvent(long id, [FromBody] Event updatedEvent)
        {
            var eventt = this.subNineRepository.Update(id, updatedEvent);
            var eventtResult = this.mapper.Map<EventDetailDTO>(eventt);

            return eventtResult;
        }
    }
}