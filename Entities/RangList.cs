using System.ComponentModel.DataAnnotations;

namespace SubNineAPI.Entities
{
    public class RangList : AppModel
    {
        [Required]
        public int Place { get; set; }

        //public long EventId { get; set; }
        //public Event Event { get; set; }
        //public long AthleteId { get; set; }
        //public Athlete Athlete { get; set; }
    }
}