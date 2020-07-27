using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class City : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //public long CountryId { get; set; }
        //public Country Country { get; set; }
    }
}