using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Participation : AppModel
    {
        [Required]
        public double Result { get; set; }

        public long AthleteId { get; set; }
        public Athlete Athlete { get; set; }
        public long DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public long? EventId { get; set; }
        public Event Event { get; set; }
    }
}