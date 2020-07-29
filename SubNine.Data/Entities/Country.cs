using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Country : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Athlete> Athletes { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}