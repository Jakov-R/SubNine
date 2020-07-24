using System.ComponentModel.DataAnnotations;

namespace SubNineAPI.Entities
{
    public class Participation : AppModel
    {
        [Required]
        public double Result { get; set; }

        //public long AthleteId { get; set; }
        //public long DisciplineId { get; set; }
        //public long EventId { get; set; }
    }
}