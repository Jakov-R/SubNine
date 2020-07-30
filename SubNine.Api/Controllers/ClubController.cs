using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories.Clubs;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/clubs")]
    public class ClubController : BaseController
    {
        private readonly IClubRepository clubRepository;
        private readonly IMapper mapper;

        public ClubController(
            IClubRepository clubRepository,
            IMapper mapper
        )
        {
            this.clubRepository = clubRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClubDetailDTO>> GetClubs([FromQuery] string search)
        {
            var club = this.clubRepository.GetAll(search);
            var clubDTO = this.mapper.Map<IEnumerable<ClubDetailDTO>>(club);

            return Ok(clubDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<ClubDetailDTO> GetClub(long id)
        {
            var club = this.clubRepository.GetOne(id);
            var clubDto = this.mapper.Map<ClubDetailDTO>(club);

            return Ok(clubDto);
        }

        [HttpPost]
        public ActionResult<ClubDetailDTO> CreateClub(ClubCreateDTO clubDTO)
        {
            var club = this.mapper.Map<Club>(clubDTO);
            club = this.clubRepository.Create(club);

            return this.mapper.Map<ClubDetailDTO>(club);
        }

        [HttpPatch("{id}")]
        public ActionResult<ClubDetailDTO> Patch(long id, [FromBody]JsonPatchDocument<Club> doc)
        {
            var club = this.clubRepository.GetOne(id);
            doc.ApplyTo(club, ModelState);

            return Ok(this.mapper.Map<ClubDetailDTO>(club));
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteClub(long id)
        {
            return new { success = this.clubRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<ClubDetailDTO> UpdateClub(long id, [FromBody] Club updatedClub)
        {
            var club = this.clubRepository.Update(id, updatedClub);
            var clubResult = this.mapper.Map<ClubDetailDTO>(club);

            return clubResult;
        }
    }
}