namespace SubNine.Data.Models
{
    public class ParticipationDetailDTO
    {
        public long Id { get; set; }

        public double Result { get; set; }
        public long AthleteId { get; set; }
        public long DisciplineId { get; set; }
        public long EventId { get; set; }
    }
}