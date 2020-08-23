using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SubNine.Api.Helpers;
using SubNine.Api.Requests.Athletes;
using SubNine.Api.Responses.Athletes;
using SubNine.Api.Services;
using SubNine.Core.Repositories;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/athletes")]
    public class AthleteController : BaseController
    {
        private readonly IAthleteRepository subNineRepository;
        private readonly IAthleteService athleteService;
        private readonly IMapper mapper;

        public AthleteController(
            IAthleteRepository subNineRepository,
            IAthleteService athleteService,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.athleteService = athleteService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<AthletePaginatedResponse> GetAthletes([FromQuery] PaginatedAthleteRequest request)
        {
            var athlete = this.athleteService.GetPaginatedResponse(request);
            //var athleteDTO = this.mapper.Map<IEnumerable<AthleteDetailMore>>(athlete);

            return Ok(athlete);
        }

        [HttpGet("{id}")]
        public ActionResult<AthleteDetailMore> GetAthlete(long id)
        {
            var athlete = this.subNineRepository.GetOne(id);
            var athleteDto = this.mapper.Map<AthleteDetailMore>(athlete);

            return Ok(athleteDto);
        }

        [Authorize]
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

        [HttpPatch("{id}")]
        public ActionResult<AthleteDetail> Patch(int id, [FromBody]JsonPatchDocument<Athlete> doc)
        {
            var athlete = this.subNineRepository.GetOne(id);
            this.subNineRepository.Patch(id, doc);
            return Ok(athlete);
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