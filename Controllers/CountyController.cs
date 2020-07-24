using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNineAPI.Entities;
using SubNineAPI.Entities.DTO;
using SubNineAPI.Repositories;

namespace SubNineAPI.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryController : AppController
    {
        private readonly ISubNineRepository<Country> subNineRepository;
        private readonly IMapper mapper;

        public CountryController(
            ISubNineRepository<Country> subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CountryDetailDTO>> GetCountries()
        {
            var country = this.subNineRepository.GetAll();
            var countryDTO = this.mapper.Map<IEnumerable<CountryDetailDTO>>(country);

            return Ok(countryDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<CountryDetailDTO> GetCountry(long id)
        {
            var country = this.subNineRepository.GetOne(id);
            var countryDto = this.mapper.Map<CountryDetailDTO>(country);

            return Ok(countryDto);
        }

        [HttpPost]
        public ActionResult<CountryDetailDTO> CreateCountry(CountryCreateDTO countryDTO)
        {
            var country = this.mapper.Map<Country>(countryDTO);
            country = this.subNineRepository.Create(country);

            return this.mapper.Map<CountryDetailDTO>(country);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteCountry(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<CountryDetailDTO> UpdateCountry(long id, [FromBody] Country updatedCountry)
        {
            var country = this.subNineRepository.Update(id, updatedCountry);
            var countryResult = this.mapper.Map<CountryDetailDTO>(country);

            return countryResult;
        }
    }
}