namespace SubNine.Data.Models
{
    public class RangListDetailMore : RangListDetail
    {
        public long Id { get; set; }
        public AthleteDetail Athlete { get; set; }
        public EventDetail Event { get; set; }
    }
}