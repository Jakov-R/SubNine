using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;
using SubNineAPI.Repositories;

namespace SubNineAPI.Controllers
{
    [ApiController]
    [Route("api/rangList")]
    public class RangListController : AppController
    {
        private readonly ISubNineRepository<RangList> subNineRepository;
        private readonly IMapper mapper;

        public RangListController(
            ISubNineRepository<RangList> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RangListDetailDTO>> GetRangLists()
        {
            var rangList = this.subNineRepository.GetAll();
            var rangListDTO = this.mapper.Map<IEnumerable<RangListDetailDTO>>(rangList);

            return Ok(rangListDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<RangListDetailDTO> GetRangList(long id)
        {
            var rangList = this.subNineRepository.GetOne(id);
            var rangListDto = this.mapper.Map<RangListDetailDTO>(rangList);

            return Ok(rangListDto);
        }

        [HttpPost]
        public ActionResult<RangListDetailDTO> CreateRangList(RangListCreateDTO rangListDTO)
        {
            var rangList = this.mapper.Map<RangList>(rangListDTO);
            rangList = this.subNineRepository.Create(rangList);

            return this.mapper.Map<RangListDetailDTO>(rangList);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteRangList(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<RangListDetailDTO> UpdateRangList(long id, [FromBody] RangList updatedRangList)
        {
            var rangList = this.subNineRepository.Update(id, updatedRangList);
            var rangListResult = this.mapper.Map<RangListDetailDTO>(rangList);

            return rangListResult;
        }
    }
}