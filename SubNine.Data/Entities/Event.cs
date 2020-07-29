using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubNine.Data.Entities
{
    public class Event : AppModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Participation> Participations { get; set; }
        public ICollection<RangList> RangLists { get; set; }
    }
}