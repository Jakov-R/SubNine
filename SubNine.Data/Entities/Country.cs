using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Country : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}