using System;

namespace SubNineAPI.Entities.DTO
{
    public class AthleteCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        
        public string Gender { get; set; }

        public int YearsOld { get; set; }

        //public long ClubId { get; set; }
        //public long CountryId { get; set; }
    }
}