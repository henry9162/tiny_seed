using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models
{
    public class LocalGovernment
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StateId { get; set; }
        public State? State { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}