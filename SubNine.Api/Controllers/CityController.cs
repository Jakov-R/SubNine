using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Api.Extensions;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CityController : AppController
    {
        private readonly IRepository<City> subNineRepository;
        private readonly IMapper mapper;

        public CityController(
            IRepository<City> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityDetailDTO>> GetCities([FromQuery] string search)
        {
            var city = this.subNineRepository.GetAll(search);
            var cityDTO = this.mapper.Map<IEnumerable<CityDetailDTO>>(city);

            return Ok(cityDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDetailDTO> GetCity(long id)
        {
            var city = this.subNineRepository.GetOne(id);
            var cityDto = this.mapper.Map<CityDetailDTO>(city);

            return Ok(cityDto);
        }

        [HttpPost]
        public ActionResult<CityDetailDTO> CreateCity(CityCreateDTO cityDTO)
        {
            var city = this.mapper.Map<City>(cityDTO);
            city = this.subNineRepository.Create(city);

            return this.mapper.Map<CityDetailDTO>(city);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteCity(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<CityDetailDTO> UpdateCity(long id, [FromBody] City updatedCity)
        {
            var city = this.subNineRepository.Update(id, updatedCity);
            var cityResult = this.mapper.Map<CityDetailDTO>(city);

            return cityResult;
        }
    }
}