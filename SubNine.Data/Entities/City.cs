using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class City : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Club> Clubs { get; set; }

        public long CountryId { get; set; }
        public Country Country { get; set; }
    }
}