using System;

namespace SubNine.Data.Models
{
    public class AthleteDetailDTO
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public int YearsOld { get; set; }

        public string Gender { get; set; }
    }
}