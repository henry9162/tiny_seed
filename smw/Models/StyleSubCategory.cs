using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SMW.Models.shared;

namespace SMW.Models
{
    public class StyleSubCategory : ModelTags
    {
        public int? StyleCategoryId { get; set; }
        public StyleCategory? StyleCategory { get; set; }
        public List<Style>? Styles { get; set; }
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}