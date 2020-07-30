using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories.Participations;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
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
        public ActionResult<IEnumerable<ParticipationDetailDTO>> GetParticipations([FromQuery] string search)
        {
            var participation = this.subNineRepository.GetAll(search);
            var participationDTO = this.mapper.Map<IEnumerable<ParticipationDetailDTO>>(participation);

            return Ok(participationDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<ParticipationDetailDTO> GetParticipation(long id)
        {
            var participation = this.subNineRepository.GetOne(id);
            var participationDto = this.mapper.Map<ParticipationDetailDTO>(participation);

            return Ok(participationDto);
        }

        [HttpPost]
        public ActionResult<ParticipationDetailDTO> CreateParticipation(ParticipationCreateDTO participationDTO)
        {
            var participation = this.mapper.Map<Participation>(participationDTO);
            participation = this.subNineRepository.Create(participation);

            return this.mapper.Map<ParticipationDetailDTO>(participation);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteParticipation(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<ParticipationDetailDTO> UpdateParticipation(long id, [FromBody] Participation updatedParticipation)
        {
            var participation = this.subNineRepository.Update(id, updatedParticipation);
            var participationResult = this.mapper.Map<ParticipationDetailDTO>(participation);

            return participationResult;
        }
    }
}