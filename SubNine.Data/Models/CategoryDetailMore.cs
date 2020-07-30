using System.Collections.Generic;

namespace SubNine.Data.Models
{
    public class CategoryDetailMore : CategoryDetail
    {
        public long Id { get; set; }
        public ICollection<DisciplineDetail> Disciplines { get; set; }
    }
}