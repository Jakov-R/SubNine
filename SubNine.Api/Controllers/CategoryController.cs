using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories.Categories;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(
            ICategoryRepository categoryRepository,
            IMapper mapper
        )
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDetailDTO>> GetCategories([FromQuery] string search)
        {
            var category = this.categoryRepository.GetAll(search);
            var categoryDTO = this.mapper.Map<IEnumerable<CategoryDetailDTO>>(category);

            return Ok(categoryDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDetailDTO> GetCategory(long id)
        {
            var category = this.categoryRepository.GetOne(id);
            var categoryDTO = this.mapper.Map<CategoryDetailDTO>(category);

            return Ok(categoryDTO);
        }

        [HttpPost]
        public ActionResult<CategoryDetailDTO> CreateAthlete(CategoryCreateDTO categoryDTO)
        {
            var category = this.mapper.Map<Category>(categoryDTO);
            category = this.categoryRepository.Create(category);

            return this.mapper.Map<CategoryDetailDTO>(category);
        }

        [HttpPatch("{id}")]
        public ActionResult<CategoryDetailDTO> Patch(long id, [FromBody]JsonPatchDocument<Category> doc)
        {
            var category = this.categoryRepository.GetOne(id);
            doc.ApplyTo(category, ModelState);

            return Ok(this.mapper.Map<CategoryDetailDTO>(category));
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteAthlete(long id)
        {
            return new { success = this.categoryRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryDetailDTO> UpdateCategory(long id, [FromBody] Category updatedCategory)
        {
            var category = this.categoryRepository.Update(id, updatedCategory);
            var categoryResult = this.mapper.Map<CategoryDetailDTO>(category);

            return categoryResult;
        }
    }
}