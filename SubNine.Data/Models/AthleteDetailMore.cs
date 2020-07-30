using System;

namespace SubNine.Data.Models
{
    public class AthleteDetailMore : AthleteDetail
    {
        public long Id { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public ClubDetail Club { get; set; }
        public CountryDetail Country { get; set; }
    }
}