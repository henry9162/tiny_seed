using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models
{
    public class StyleCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Sex { get; set; }
        public List<StyleSubCategory>? StyleSubCategories { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}