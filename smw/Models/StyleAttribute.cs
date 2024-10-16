using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models.shared;

namespace SMW.Models
{
    public class StyleAttribute : ModelTags
    {
        [Required]
        public string? Sex { get; set; }
        public string? ImagePath { get; set; }
        public string? ImageName { get; set; }
        public List<Style>? Styles { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}