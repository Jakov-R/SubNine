using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SubNine.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}