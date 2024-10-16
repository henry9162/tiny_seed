using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.ResponseDtos.StyleDto
{
    public class StyleRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Sex { get; set; }
        [Required]
        public int FabricSet { get; set; }
        public string? Colors { get; set; }
        [Required]
        public int StyleSubCategoryId { get; set; }
        [Required]
        public List<IFormFile>? ImageFiles { get; set; }
        [Required]
        public List<int>? AttributeIds { get; set; }
    }
}