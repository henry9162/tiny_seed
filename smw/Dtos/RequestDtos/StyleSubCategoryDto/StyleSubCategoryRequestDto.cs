using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMW.Dtos.RequestDtos.StyleSubCategoryDto
{
    public class StyleSubCategoryRequestDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int StyleCategoryId { get; set; }
    }
}