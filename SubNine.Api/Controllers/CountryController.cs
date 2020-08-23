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
    [Route("api/countries")]
    public class CountryController : BaseController
    {
        private readonly ICountryRepository subNineRepository;
        private readonly IMapper mapper;

        public CountryController(
            ICountryRepository subNineRepository,
            IMapper mapper
        )
        {
            this.subNineRepository = subNineRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CountryDetailMore>> GetCountries([FromQuery] string search)
        {
            var country = this.subNineRepository.GetAll(search);
            var countryDTO = this.mapper.Map<IEnumerable<CountryDetailMore>>(country);

            return Ok(countryDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<CountryDetailMore> GetCountry(long id)
        {
            var country = this.subNineRepository.GetOne(id);
            var countryDto = this.mapper.Map<CountryDetailMore>(country);

            return Ok(countryDto);
        }

        [HttpPost]
        public ActionResult<CountryDetail> CreateCountry(CountryCreate countryDTO)
        {
            var country = this.mapper.Map<Country>(countryDTO);
            country = this.subNineRepository.Create(country);

            return this.mapper.Map<CountryDetail>(country);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteCountry(long id)
        {
            return new { success = this.subNineRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<CountryDetail> UpdateCountry(long id, [FromBody] Country updatedCountry)
        {
            var country = this.subNineRepository.Update(id, updatedCountry);
            var countryResult = this.mapper.Map<CountryDetail>(country);

            return countryResult;
        }

        [HttpPatch("{id}")]
        public ActionResult<CountryDetail> Patch(int id, [FromBody]JsonPatchDocument<Country> doc)
        {
            var country = this.subNineRepository.GetOne(id);
            this.subNineRepository.Patch(id, doc);
            return Ok(country);
        }
    }
}