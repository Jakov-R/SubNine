using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Discipline : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Participation> Participtions { get; set; }
    }
}