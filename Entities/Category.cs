using System.ComponentModel.DataAnnotations;

namespace SubNineAPI.Entities
{
    public class Category : AppModel
    {
        [Required]
        public string Name { get; set; }
    }
}