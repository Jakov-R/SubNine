using System.Collections.Generic;
using SubNine.Data.Entities;

namespace SubNine.Data.Models
{
    public class CountryDetailMore : CountryDetail
    {
        public long Id { get; set; }
        public string Label { get; set; }

        public ICollection<CityDetail> Cities { get; set; }
    }
}