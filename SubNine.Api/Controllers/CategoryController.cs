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
    [Route("api/categories")]
    public class CategoryController : AppController
    {
        private readonly IRepository<Category> subNineRepository;
        private readonly IMapper mapper;

        public CategoryController(
            IRepository<Category> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDetailDTO>> GetCategories([FromQuery] string search)
        {
            var category = this.subNineRepository.GetAll(search);
            var categoryDTO = this.mapper.Map<IEnumerable<CategoryDetailDTO>>(category);

            return Ok(categoryDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDetailDTO> GetCategory(long id)
        {
            var category = this.subNineRepository.GetOne(id);
            var categoryDTO = this.mapper.Map<CategoryDetailDTO>(category);

            return Ok(categoryDTO);
        }

        [HttpPost]
        public ActionResult<CategoryDetailDTO> CreateAthlete(CategoryCreateDTO categoryDTO)
        {
            var category = this.mapper.Map<Category>(categoryDTO);
            category = this.subNineRepository.Create(category);

            return this.mapper.Map<CategoryDetailDTO>(category);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteAthlete(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryDetailDTO> UpdateCategory(long id, [FromBody] Category updatedCategory)
        {
            var category = this.subNineRepository.Update(id, updatedCategory);
            var categoryResult = this.mapper.Map<CategoryDetailDTO>(category);

            return categoryResult;
        }
    }
}