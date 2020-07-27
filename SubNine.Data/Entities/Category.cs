using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Category : AppModel
    {
        [Required]
        public string Name { get; set; }
    }
}