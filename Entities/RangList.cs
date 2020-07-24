using System.ComponentModel.DataAnnotations;

namespace SubNineAPI.Entities
{
    public class RangList : AppModel
    {
        [Required]
        public int Place { get; set; }

        //public long EventId { get; set; }
        //public long AthleteId { get; set; }
    }
}