using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Club : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string ShirtColor { get; set; }

        public ICollection<Athlete> Athletes { get; set; }

        public long CityId { get; set; }
        public City City { get; set; }
    }
}