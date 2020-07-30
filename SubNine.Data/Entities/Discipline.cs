using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Discipline : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Participation> Participtions { get; set; }
    }
}