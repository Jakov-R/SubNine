using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/clubs")]
    public class ClubController : BaseController
    {
        private readonly IClubRepository subNineRepository;
        private readonly IMapper mapper;

        public ClubController(
            IClubRepository subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClubDetailMore>> GetClubs([FromQuery] string search)
        {
            var club = this.subNineRepository.GetAll(search);
            var clubDTO = this.mapper.Map<IEnumerable<ClubDetailMore>>(club);

            return Ok(clubDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<ClubDetailMore> GetClub(long id)
        {
            var club = this.subNineRepository.GetOne(id);
            var clubDto = this.mapper.Map<ClubDetailMore>(club);

            return Ok(clubDto);
        }

        [HttpPost]
        public ActionResult<ClubDetailMore> CreateClub(ClubCreate clubDTO)
        {
            var club = this.mapper.Map<Club>(clubDTO);
            club = this.subNineRepository.Create(club);

            return this.mapper.Map<ClubDetailMore>(club);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteClub(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<ClubDetailMore> UpdateClub(long id, [FromBody] Club updatedClub)
        {
            var club = this.subNineRepository.Update(id, updatedClub);
            var clubResult = this.mapper.Map<ClubDetailMore>(club);

            return clubResult;
        }
    }
}