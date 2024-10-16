using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Models
{
    public class Style
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Sex { get; set; }
        [Required]
        public List<StyleImage>? StyleImages { get; set; }
        [Required]
        public string? Colors { get; set; }
        public int FabricSet { get; set; } // two piece, 3 piece. important for frontend to know
        [Required]
        public double Amount { get; set; }
        [Required]
        public int? StyleSubCategoryId { get; set; }
        public StyleSubCategory? StyleSubCategory { get; set; }
        public List<StyleAttribute>? StyleAttributes { get; set; }
        public List<CustomRequest>? CustomRequests { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}