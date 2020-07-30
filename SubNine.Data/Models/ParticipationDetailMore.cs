namespace SubNine.Data.Models
{
    public class ParticipationDetailMore : ParticipationDetail
    {
        public long Id { get; set; }
        public AthleteDetail Athlete { get; set; }
        public DisciplineDetail Discipline { get; set; }
        public EventDetail Event { get; set; }
    }
}