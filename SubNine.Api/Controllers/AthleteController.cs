using System.Collections.Generic;
using AutoMapper;
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
        private readonly IAthleteRepository subNineRepository;
        private readonly IMapper mapper;

        public AthleteController(
            IAthleteRepository subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AthleteDetailMore>> GetAthletes([FromQuery] string search)
        {
            var athlete = this.subNineRepository.GetAll(search);
            var athleteDTO = this.mapper.Map<IEnumerable<AthleteDetailMore>>(athlete);

            return Ok(athleteDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<AthleteDetailMore> GetAthlete(long id)
        {
            var athlete = this.subNineRepository.GetOne(id);
            var athleteDto = this.mapper.Map<AthleteDetailMore>(athlete);

            return Ok(athleteDto);
        }

        [HttpPost]
        public ActionResult<AthleteDetail> CreateAthlete(AthleteCreate athleteDTO)
        {
            var athlete = this.mapper.Map<Athlete>(athleteDTO);
            athlete = this.subNineRepository.Create(athlete);

            return this.mapper.Map<AthleteDetail>(athlete);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteAthlete(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<AthleteDetailMore> UpdateAthlete(long id, [FromBody] Athlete updatedAthlete)
        {
            var athlete = this.subNineRepository.Update(id, updatedAthlete);
            var athleteResult = this.mapper.Map<AthleteDetailMore>(athlete);

            return athleteResult;
        }
    }
}