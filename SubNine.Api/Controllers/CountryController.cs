using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubNine.Core.Repositories.Countries;
using SubNine.Core.Repositories;
using SubNine.Data.Database;
using SubNine.Data.Entities;
using SubNine.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace SubNine.Api.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : BaseController
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountryController(
            ICountryRepository countryRepository,
            IMapper mapper
        )
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CountryDetailDTO>> GetCountries([FromQuery] string search)
        {
            var country = this.countryRepository.GetAll(search);
            var countryDTO = this.mapper.Map<IEnumerable<CountryDetailDTO>>(country);

            return Ok(countryDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<CountryDetailDTO> GetCountry(long id)
        {
            var country = this.countryRepository.GetOne(id);
            var countryDto = this.mapper.Map<CountryDetailDTO>(country);

            return Ok(countryDto);
        }

        [HttpPost]
        public ActionResult<CountryDetailDTO> CreateCountry(CountryCreateDTO countryDTO)
        {
            var country = this.mapper.Map<Country>(countryDTO);
            country = this.countryRepository.Create(country);

            return this.mapper.Map<CountryDetailDTO>(country);
        }

        [HttpPatch("{id}")]
        public ActionResult<CountryDetailDTO> Patch(long id, [FromBody]JsonPatchDocument<Country> doc)
        {
            var country = this.countryRepository.GetOne(id);
            doc.ApplyTo(country, ModelState);

            return Ok(this.mapper.Map<CountryDetailDTO>(country));
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteCountry(long id)
        {
            return new { success = this.countryRepository.Delete(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<CountryDetailDTO> UpdateCountry(long id, [FromBody] Country updatedCountry)
        {
            var country = this.countryRepository.Update(id, updatedCountry);
            var countryResult = this.mapper.Map<CountryDetailDTO>(country);

            return countryResult;
        }
    }
}