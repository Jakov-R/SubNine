using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Discipline> Disciplines { get; set; }
    }
}