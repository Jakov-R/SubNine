using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories.Athletes;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/athletes")]
    public class AthleteController : BaseController
    {
        private readonly IAthleteRepository athleteRepository;
        private readonly IMapper mapper;

        public AthleteController(
            IAthleteRepository athleteRepository,
            IMapper mapper
        )
        {
            this.athleteRepository = athleteRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AthleteDetailDTO>> GetAthletes([FromQuery] string search)
        {
            var athlete = this.athleteRepository.GetAll(search);
            var athleteDTO = this.mapper.Map<IEnumerable<AthleteDetailDTO>>(athlete);

            return Ok(athleteDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<AthleteDetailDTO> GetAthlete(long id)
        {
            var athlete = this.athleteRepository.GetOne(id);
            var athleteDto = this.mapper.Map<AthleteDetailDTO>(athlete);

            return Ok(athleteDto);
        }

        [HttpPost]
        public ActionResult<AthleteDetailDTO> CreateAthlete(AthleteCreateDTO athleteDTO)
        {
            var athlete = this.mapper.Map<Athlete>(athleteDTO);
            athlete = this.athleteRepository.Create(athlete);

            return Ok(this.mapper.Map<AthleteDetailDTO>(athlete));
        }

        [HttpPatch("{id}")]
        public ActionResult<AthleteDetailDTO> Patch(long id, [FromBody]JsonPatchDocument<Athlete> doc)
        {
            var athlete = this.athleteRepository.GetOne(id);
            doc.ApplyTo(athlete, ModelState);

            return Ok(this.mapper.Map<AthleteDetailDTO>(athlete));
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteAthlete(long id)
        {
            return new { success = this.athleteRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<AthleteDetailDTO> UpdateAthlete(long id, [FromBody] Athlete updatedAthlete)
        {
            var athlete = this.athleteRepository.Update(id, updatedAthlete);
            var athleteResult = this.mapper.Map<AthleteDetailDTO>(athlete);

            return athleteResult;
        }
    }
}