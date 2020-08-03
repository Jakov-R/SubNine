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
    [Route("api/cities")]
    public class CityController : BaseController
    {
        private readonly ICityRepository subNineRepository;
        private readonly IMapper mapper;

        public CityController(
            ICityRepository subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityDetailMore>> GetCities([FromQuery] string search)
        {
            var city = this.subNineRepository.GetAll(search);
            var cityDTO = this.mapper.Map<IEnumerable<CityDetailMore>>(city);

            return Ok(cityDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDetailMore> GetCity(long id)
        {
            var city = this.subNineRepository.GetOne(id);
            var cityDto = this.mapper.Map<CityDetailMore>(city);

            return Ok(cityDto);
        }

        [HttpPost]
        public ActionResult<CityDetailMore> CreateCity(CityCreate cityDTO)
        {
            var city = this.mapper.Map<City>(cityDTO);
            city = this.subNineRepository.Create(city);

            return this.mapper.Map<CityDetailMore>(city);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteCity(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<CityDetailMore> UpdateCity(long id, [FromBody] City updatedCity)
        {
            var city = this.subNineRepository.Update(id, updatedCity);
            var cityResult = this.mapper.Map<CityDetailMore>(city);

            return cityResult;
        }

        [HttpPatch("{id}")]
        public ActionResult<CityDetail> Patch(int id, [FromBody]JsonPatchDocument<City> doc)
        {
            var city = this.subNineRepository.GetOne(id);
            this.subNineRepository.Patch(id, doc);
            return Ok(city);
        }
    }
}