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
    [Route("api/clubs")]
    public class ClubController : AppController
    {
        private readonly IRepository<Club> subNineRepository;
        private readonly IMapper mapper;

        public ClubController(
            IRepository<Club> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClubDetailDTO>> GetClubs([FromQuery] string search)
        {
            var club = this.subNineRepository.GetAll(search);
            var clubDTO = this.mapper.Map<IEnumerable<ClubDetailDTO>>(club);

            return Ok(clubDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<ClubDetailDTO> GetClub(long id)
        {
            var club = this.subNineRepository.GetOne(id);
            var clubDto = this.mapper.Map<ClubDetailDTO>(club);

            return Ok(clubDto);
        }

        [HttpPost]
        public ActionResult<ClubDetailDTO> CreateClub(ClubCreateDTO clubDTO)
        {
            var club = this.mapper.Map<Club>(clubDTO);
            club = this.subNineRepository.Create(club);

            return this.mapper.Map<ClubDetailDTO>(club);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteClub(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<ClubDetailDTO> UpdateClub(long id, [FromBody] Club updatedClub)
        {
            var club = this.subNineRepository.Update(id, updatedClub);
            var clubResult = this.mapper.Map<ClubDetailDTO>(club);

            return clubResult;
        }
    }
}