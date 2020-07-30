using SubNine.Data.Entities;

namespace SubNine.Data.Models
{
    public class CityDetailMore : CityDetail
    {
        public long Id { get; set; }

        public string Label { get; set; }

        public CountryDetail Country { get; set; }
    }
}