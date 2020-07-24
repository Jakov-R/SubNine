using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;
using SubNineAPI.Repositories;

namespace SubNineAPI.Controllers
{
    [ApiController]
    [Route("api/athlete")]
    public class AthleteController : AppController
    {
        private readonly ISubNineRepository<Athlete> subNineRepository;
        private readonly IMapper mapper;

        public AthleteController(
            ISubNineRepository<Athlete> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AthleteDetailDTO>> GetAthletes()
        {
            var athlete = this.subNineRepository.GetAll();
            var athleteDTO = this.mapper.Map<IEnumerable<AthleteDetailDTO>>(athlete);

            return Ok(athleteDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<AthleteDetailDTO> GetAthlete(long id)
        {
            var athlete = this.subNineRepository.GetOne(id);
            var athleteDto = this.mapper.Map<AthleteDetailDTO>(athlete);

            return Ok(athleteDto);
        }

        [HttpPost]
        public ActionResult<AthleteDetailDTO> CreateAthlete(AthleteCreateDTO athleteDTO)
        {
            var athlete = this.mapper.Map<Athlete>(athleteDTO);
            athlete = this.subNineRepository.Create(athlete);

            return this.mapper.Map<AthleteDetailDTO>(athlete);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteAthlete(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<AthleteDetailDTO> UpdateAthlete(long id, [FromBody] Athlete updatedAthlete)
        {
            var athlete = this.subNineRepository.Update(id, updatedAthlete);
            var athleteResult = this.mapper.Map<AthleteDetailDTO>(athlete);

            return athleteResult;
        }
    }
}