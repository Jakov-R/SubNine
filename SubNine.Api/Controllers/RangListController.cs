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
    [Route("api/rangLists")]
    public class RangListController : BaseController
    {
        private readonly IRangListRepository subNineRepository;
        private readonly IMapper mapper;

        public RangListController(
            IRangListRepository subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RangListDetailMore>> GetRangLists([FromQuery] string search)
        {
            var rangList = this.subNineRepository.GetAll(search);
            var rangListDTO = this.mapper.Map<IEnumerable<RangListDetailMore>>(rangList);

            return Ok(rangListDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<RangListDetailMore> GetRangList(long id)
        {
            var rangList = this.subNineRepository.GetOne(id);
            var rangListDto = this.mapper.Map<RangListDetailMore>(rangList);

            return Ok(rangListDto);
        }

        [HttpPost]
        public ActionResult<RangListDetailMore> CreateRangList(RangListCreate rangListDTO)
        {
            var rangList = this.mapper.Map<RangList>(rangListDTO);
            rangList = this.subNineRepository.Create(rangList);

            return this.mapper.Map<RangListDetailMore>(rangList);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteRangList(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<RangListDetailMore> UpdateRangList(long id, [FromBody] RangList updatedRangList)
        {
            var rangList = this.subNineRepository.Update(id, updatedRangList);
            var rangListResult = this.mapper.Map<RangListDetailMore>(rangList);

            return rangListResult;
        }

        [HttpPatch("{id}")]
        public ActionResult<RangListDetail> Patch(int id, [FromBody]JsonPatchDocument<RangList> doc)
        {
            var rangList = this.subNineRepository.GetOne(id);
            this.subNineRepository.Patch(id, doc);
            return Ok(rangList);
        }
    }
}