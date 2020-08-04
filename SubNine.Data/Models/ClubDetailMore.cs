using System.Collections.Generic;
using SubNine.Data.Entities;

namespace SubNine.Data.Models
{
    public class ClubDetailMore : ClubDetail
    {
        public long Id { get; set; }

        public string ShirtColor { get; set; }

        public CityDetail City { get; set; }

        public ICollection<AthleteDetail> Athletes { get; set; }
    }
}