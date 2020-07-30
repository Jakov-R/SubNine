using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.repositories.Disciplines;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/disciplines")]
    public class DisciplineController : AppController
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
        public ActionResult<IEnumerable<DisciplineDetailDTO>> GetDisciplines([FromQuery] string search)
        {
            var discipline = this.subNineRepository.GetAll(search);
            var disciplineDTO = this.mapper.Map<IEnumerable<DisciplineDetailDTO>>(discipline);

            return Ok(disciplineDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<DisciplineDetailDTO> GetDiscipline(long id)
        {
            var discipline = this.subNineRepository.GetOne(id);
            var disciplineDto = this.mapper.Map<DisciplineDetailDTO>(discipline);

            return Ok(disciplineDto);
        }

        [HttpPost]
        public ActionResult<DisciplineDetailDTO> CreateDiscipline(DisciplineCreateDTO disciplineDTO)
        {
            var discipline = this.mapper.Map<Discipline>(disciplineDTO);
            discipline = this.subNineRepository.Create(discipline);

            return this.mapper.Map<DisciplineDetailDTO>(discipline);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteDiscipline(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<DisciplineDetailDTO> UpdateDiscipline(long id, [FromBody] Discipline updatedDiscipline)
        {
            var discipline = this.subNineRepository.Update(id, updatedDiscipline);
            var disciplineResult = this.mapper.Map<DisciplineDetailDTO>(discipline);

            return disciplineResult;
        }
    }
}