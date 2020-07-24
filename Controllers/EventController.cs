using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;
using SubNineAPI.Repositories;

namespace SubNineAPI.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : AppController
    {
        private readonly ISubNineRepository<Event> subNineRepository;
        private readonly IMapper mapper;

        public EventController(
            ISubNineRepository<Event> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDetailDTO>> GetEvents()
        {
            var eventt = this.subNineRepository.GetAll();
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