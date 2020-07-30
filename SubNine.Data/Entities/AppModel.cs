using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}