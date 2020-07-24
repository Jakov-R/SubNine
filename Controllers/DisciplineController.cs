using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;
using SubNineAPI.Repositories;

namespace SubNineAPI.Controllers
{
    [ApiController]
    [Route("api/discipline")]
    public class DisciplineController : AppController
    {
        private readonly ISubNineRepository<Discipline> subNineRepository;
        private readonly IMapper mapper;

        public DisciplineController(
            ISubNineRepository<Discipline> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DisciplineDetailDTO>> GetDisciplines()
        {
            var discipline = this.subNineRepository.GetAll();
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