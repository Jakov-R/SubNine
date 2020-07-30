namespace SubNine.Data.Models
{
    public class DisciplineDetailMore : DisciplineDetail
    {
        public long Id { get; set; }
        public CategoryDetail Category { get; set; }
    }
}