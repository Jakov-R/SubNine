using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubNine.Data.Entities
{
    public class Athlete : BaseEntity
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

        public long ClubId { get; set; }
        public Club Club { get; set; }
        
        public long? CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Participation> Participations { get; set; }
        public ICollection<RangList> RangLists { get; set; }
    }
}