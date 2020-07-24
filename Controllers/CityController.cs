using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;
using SubNineAPI.Repositories;

namespace SubNineAPI.Controllers
{
    [ApiController]
    [Route("api/city")]
    public class CityController : AppController
    {
        private readonly ISubNineRepository<City> subNineRepository;
        private readonly IMapper mapper;

        public CityController(
            ISubNineRepository<City> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityDetailDTO>> GetCities()
        {
            var city = this.subNineRepository.GetAll();
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