using System.ComponentModel.DataAnnotations;

namespace SubNineAPI.Entities
{
    public class Event : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}