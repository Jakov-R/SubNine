using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Discipline : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}