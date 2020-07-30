using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories.Disciplines;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/disciplines")]
    public class DisciplineController : BaseController
    {
        private readonly IDisciplineRepository disciplineRepository;
        private readonly IMapper mapper;

        public DisciplineController(
            IDisciplineRepository disciplineRepository,
            IMapper mapper
        )
        {
            this.disciplineRepository = disciplineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DisciplineDetailDTO>> GetDisciplines([FromQuery] string search)
        {
            var discipline = this.disciplineRepository.GetAll(search);
            var disciplineDTO = this.mapper.Map<IEnumerable<DisciplineDetailDTO>>(discipline);

            return Ok(disciplineDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<DisciplineDetailDTO> GetDiscipline(long id)
        {
            var discipline = this.disciplineRepository.GetOne(id);
            var disciplineDto = this.mapper.Map<DisciplineDetailDTO>(discipline);

            return Ok(disciplineDto);
        }

        [HttpPost]
        public ActionResult<DisciplineDetailDTO> CreateDiscipline(DisciplineCreateDTO disciplineDTO)
        {
            var discipline = this.mapper.Map<Discipline>(disciplineDTO);
            discipline = this.disciplineRepository.Create(discipline);

            return this.mapper.Map<DisciplineDetailDTO>(discipline);
        }

        [HttpPatch("{id}")]
        public ActionResult<DisciplineDetailDTO> Patch(long id, [FromBody]JsonPatchDocument<Discipline> doc)
        {
            var discipline = this.disciplineRepository.GetOne(id);
            doc.ApplyTo(discipline, ModelState);

            return Ok(this.mapper.Map<DisciplineDetailDTO>(discipline));
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteDiscipline(long id)
        {
            return new { success = this.disciplineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<DisciplineDetailDTO> UpdateDiscipline(long id, [FromBody] Discipline updatedDiscipline)
        {
            var discipline = this.disciplineRepository.Update(id, updatedDiscipline);
            var disciplineResult = this.mapper.Map<DisciplineDetailDTO>(discipline);

            return disciplineResult;
        }
    }
}