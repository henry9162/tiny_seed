using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SMW.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<LocalGovernment>? LocalGovernments { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}