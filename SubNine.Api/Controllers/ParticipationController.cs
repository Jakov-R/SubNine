using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/participations")]
    public class ParticipationController : BaseController
    {
        private readonly IParticipationRepository subNineRepository;
        private readonly IMapper mapper;

        public ParticipationController(
            IParticipationRepository subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParticipationDetailMore>> GetParticipations([FromQuery] string search)
        {
            var participation = this.subNineRepository.GetAll(search);
            var participationDTO = this.mapper.Map<IEnumerable<ParticipationDetailMore>>(participation);

            return Ok(participationDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<ParticipationDetailMore> GetParticipation(long id)
        {
            var participation = this.subNineRepository.GetOne(id);
            var participationDto = this.mapper.Map<ParticipationDetailMore>(participation);

            return Ok(participationDto);
        }

        [HttpPost]
        public ActionResult<ParticipationDetailMore> CreateParticipation(ParticipationCreate participationDTO)
        {
            var participation = this.mapper.Map<Participation>(participationDTO);
            participation = this.subNineRepository.Create(participation);

            return this.mapper.Map<ParticipationDetailMore>(participation);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteParticipation(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<ParticipationDetailMore> UpdateParticipation(long id, [FromBody] Participation updatedParticipation)
        {
            var participation = this.subNineRepository.Update(id, updatedParticipation);
            var participationResult = this.mapper.Map<ParticipationDetailMore>(participation);

            return participationResult;
        }
    }
}