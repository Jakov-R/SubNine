using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/disciplines")]
    public class DisciplineController : BaseController
    {
        private readonly IDisciplineRepository subNineRepository;
        private readonly IMapper mapper;

        public DisciplineController(
            IDisciplineRepository subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DisciplineDetailMore>> GetDisciplines([FromQuery] string search)
        {
            var discipline = this.subNineRepository.GetAll(search);
            var disciplineDTO = this.mapper.Map<IEnumerable<DisciplineDetailMore>>(discipline);

            return Ok(disciplineDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<DisciplineDetailMore> GetDiscipline(long id)
        {
            var discipline = this.subNineRepository.GetOne(id);
            var disciplineDTO = this.mapper.Map<DisciplineDetailMore>(discipline);

            return Ok(disciplineDTO);
        }

        [HttpPost]
        public ActionResult<DisciplineDetailMore> CreateDiscipline(DisciplineCreate disciplineDTO)
        {
            var discipline = this.mapper.Map<Discipline>(disciplineDTO);
            discipline = this.subNineRepository.Create(discipline);

            return this.mapper.Map<DisciplineDetailMore>(discipline);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteDiscipline(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<DisciplineDetailMore> UpdateDiscipline(long id, [FromBody] Discipline updatedDiscipline)
        {
            var discipline = this.subNineRepository.Update(id, updatedDiscipline);
            var disciplineResult = this.mapper.Map<DisciplineDetailMore>(discipline);

            return disciplineResult;
        }

        [HttpPatch("{id}")]
        public ActionResult<DisciplineDetail> Patch(int id, [FromBody]JsonPatchDocument<Discipline> doc)
        {
            var discipline = this.subNineRepository.GetOne(id);
            this.subNineRepository.Patch(id, doc);
            return Ok(discipline);
        }
    }
}