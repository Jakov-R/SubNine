using System;
using System.ComponentModel.DataAnnotations;

namespace SubNineAPI.Entities
{
    public class Athlete : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        //public long ClubId { get; set; }
        //public long CountryId { get; set; }
    }
}