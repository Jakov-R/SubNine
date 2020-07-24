using System.ComponentModel.DataAnnotations;

namespace SubNineAPI.Entities
{
    public class Discipline : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}