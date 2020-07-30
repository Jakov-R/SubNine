namespace SubNine.Data.Models
{
    public class ParticipationCreate
    {
        public double Result { get; set; }

        public long AthleteId { get; set; }
        public long DisciplineId { get; set; }
        public long EventId { get; set; }
    }
}